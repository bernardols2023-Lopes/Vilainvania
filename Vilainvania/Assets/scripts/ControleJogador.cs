using UnityEngine;
using UnityEngine.InputSystem; // Garanta que essa linha está no topo do seu script

public class ControleJogador : MonoBehaviour
{
    public float velocidade = 8f;
    public float forcaPulo = 12f;
    private Rigidbody2D rb;
    private bool estaNoChao;
    private float movimentoX;

    // --- VARIÁVEL PARA CONTROLAR O DESENHO DA IMAGEM ---
    private SpriteRenderer spriteRenderer;

    // --- VARIÁVEIS PARA O SOM ---
    [Header("Configurações de Áudio")]
    public AudioSource audioSource;
    public AudioClip somPulo;
    public AudioClip somTiro;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Pega automaticamente o componente de imagem do seu personagem
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimento A e D
        if (Keyboard.current != null)
        {
            float esquerda = Keyboard.current.aKey.isPressed ? -1f : 0f;
            float direita = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoX = esquerda + direita;

            // --- RESOLUÇÃO DEFINITIVA DO GIRO USANDO FLIP VISUAL ---
            if (spriteRenderer != null)
            {
                if (movimentoX > 0f)
                {
                    // Andando para a direita: desmarca o espelhamento (olha para a direita)
                    spriteRenderer.flipX = true;
                }
                else if (movimentoX < 0f)
                {
                    // Andando para a esquerda: marca o espelhamento (olha para a esquerda)
                    spriteRenderer.flipX = false;
                }
            }

            // Pulo (Espaço)
            if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
                audioSource.PlayOneShot(somPulo);
            }

            // Botão de Tiro (Clique Esquerdo do Mouse)
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                audioSource.PlayOneShot(somTiro);
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimentoX * velocidade, rb.linearVelocity.y);
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
