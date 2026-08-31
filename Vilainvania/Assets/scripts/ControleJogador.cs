using UnityEngine;
using UnityEngine.InputSystem; // Garanta que essa linha está no topo do seu script

public class ControleJogador : MonoBehaviour
{
    public float velocidade = 8f;
    public float forcaPulo = 12f;
    private Rigidbody2D rb;
    private bool estaNoChao;
    private float movimentoX;

    // --- VARIÁVEIS PARA O SOM ---
    [Header("Configurações de Áudio")]
    public AudioSource audioSource;
    public AudioClip somPulo;
    public AudioClip somTiro; // ADICIONADO: Variável para o som de tiro

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento A e D
        if (Keyboard.current != null)
        {
            float esquerda = Keyboard.current.aKey.isPressed ? -1f : 0f;
            float direita = Keyboard.current.dKey.isPressed ? 1f : 0f;
            movimentoX = esquerda + direita;

            // Pulo (Espaço)
            if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
                audioSource.PlayOneShot(somPulo);
            }

            // --- ADICIONADO: Botão de Tiro (Clique Esquerdo do Mouse) ---
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                audioSource.PlayOneShot(somTiro);
                // Aqui você pode colocar a lógica futura de criar a bala (Instantiate)
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
