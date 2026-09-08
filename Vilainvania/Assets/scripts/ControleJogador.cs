using UnityEngine;
using UnityEngine.InputSystem; // Garanta que essa linha está no topo do seu script

public class ControlaJogador : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidadeAndar = 5f;
    public float velocidadeCorrer = 8f;
    public float forcaPulo = 12f;

    private float velocidadeAtual;
    private Rigidbody2D rb;
    private bool estaNoChao;
    private float movimentoX;
    private bool estaVivo = true;

    // -- VARIAVEL PARA CONTROLAR O DESENHO DA IMAGEM --
    private SpriteRenderer spriteRenderer;

    // -- VARIAVEL PARA O ANIMATOR --
    private Animator anim;

    // -- VARIAVEIS PARA O SOM --
    [Header("Configurações de Áudio")]
    public AudioSource audioSource;
    public AudioClip somPulo;
    public AudioClip somTiro;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Pega automaticamente o componente de imagem do seu personagem
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Pega automaticamente o componente de animação do seu personagem
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Se o jogador morreu, impede qualquer comando ou movimento
        if (!estaVivo) return;

        // Movimento A e D
        if (Keyboard.current != null)
        {
            // Correção da direção: Direita (positivo) menos Esquerda (negativo)
            float esquerda = Keyboard.current.aKey.isPressed ? 1f : 0f;
            float direita = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoX = direita - esquerda;

            // Lógica de Correr: Se segurar o Shift Esquerdo, muda a velocidade
            if (Keyboard.current.leftShiftKey.isPressed && movimentoX != 0f)
            {
                velocidadeAtual = velocidadeCorrer;
            }
            else
            {
                velocidadeAtual = velocidadeAndar;
            }
        }

        // RESOLUÇÃO DEFINITIVA DO GIRO USANDO FLIP VISUAL
        if (spriteRenderer != null)
        {
            if (movimentoX > 0f)
            {
                spriteRenderer.flipX = false;
            }
            else if (movimentoX < 0f)
            {
                spriteRenderer.flipX = true;
            }
        }

        // Pulo (Espaço)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);

            if (audioSource != null && somPulo != null)
                audioSource.PlayOneShot(somPulo);
        }

        // Botão de Ataque/Tiro (Clique Esquerdo do Mouse)
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Ativa o gatilho de ataque no Animator
            if (anim != null) anim.SetTrigger("attack");

            if (audioSource != null && somTiro != null)
                audioSource.PlayOneShot(somTiro);
        }

        // ENVIAR AS INFORMAÇÕES PARA O ANIMATOR
        if (anim != null)
        {
            // Idle e Andar são controlados por essa linha (se for 0 é Idle, se não for é andando)
            anim.SetBool("isWalking", movimentoX != 0f && velocidadeAtual == velocidadeAndar);

            // Controle da animação de Correr
            anim.SetBool("isRunning", movimentoX != 0f && velocidadeAtual == velocidadeCorrer);

            anim.SetBool("isGrounded", estaNoChao);
            anim.SetFloat("yVelocity", rb.linearVelocity.y);
        }
    }

    void FixedUpdate()
    {
        if (!estaVivo)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(movimentoX * velocidadeAtual, rb.linearVelocity.y);
    }

    // FUNÇÃO PÚBLICA PARA FAZER O PERSONAGEM TOMAR DANO (Chame a partir dos inimigos/espinhos)
    public void TomarDano()
    {
        if (!estaVivo) return;

        if (anim != null)
        {
            anim.SetTrigger("takeDamage");
        }
    }

    // FUNÇÃO PÚBLICA PARA FAZER O PERSONAGEM MORRER
    public void Morrer()
    {
        if (!estaVivo) return;

        estaVivo = false;

        if (anim != null)
        {
            anim.SetTrigger("die");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao")) estaNoChao = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao")) estaNoChao = false;
    }
}
