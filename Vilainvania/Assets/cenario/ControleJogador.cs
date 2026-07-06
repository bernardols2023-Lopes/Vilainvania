using UnityEngine;
using UnityEngine.InputSystem; // Importante adicionar esta linha

public class ControleJogador : MonoBehaviour
{
    public float velocidade = 8f;
    public float forcaPulo = 12f;
    private Rigidbody2D rb;
    private bool estaNoChao;
    private float movimentoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento A e D (Novo Sistema)
        if (Keyboard.current != null)
        {
            float esquerda = Keyboard.current.aKey.isPressed ? -1f : 0f;
            float direita = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoX = esquerda + direita;

            // Pulo (Espaço)
            if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            }
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimento no X mantendo a física do Y
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

