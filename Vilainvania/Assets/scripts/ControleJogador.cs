using UnityEngine;
using UnityEngine.InputSystem;

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

    private SpriteRenderer spriteRenderer;

    private Animator anim;

    [Header("Configurações de Áudio")]
    public AudioSource audioSource;
    public AudioClip somPulo;
    public AudioClip somTiro;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!estaVivo) return;

        if (Keyboard.current != null)
        {
            float esquerda = Keyboard.current.aKey.isPressed ? 1f : 0f;
            float direita = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoX = direita - esquerda;

            if (Keyboard.current.leftShiftKey.isPressed && movimentoX != 0f)
            {
                velocidadeAtual = velocidadeCorrer;
            }
            else
            {
                velocidadeAtual = velocidadeAndar;
            }
        }
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

        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);

            if (audioSource != null && somPulo != null)
                audioSource.PlayOneShot(somPulo);
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (anim != null) anim.SetTrigger("attack");

            if (audioSource != null && somTiro != null)
                audioSource.PlayOneShot(somTiro);
        }

        if (anim != null)
        {
            anim.SetBool("isWalking", movimentoX != 0f && velocidadeAtual == velocidadeAndar);

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

    public void TomarDano()
    {
        if (!estaVivo) return;

        if (anim != null)
        {
            anim.SetTrigger("takeDamage");
        }
    }

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
