using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;
    [SerializeField] TMP_Text vidaPlayer;

    [Header("Configurações de Piscar")]
    public Color corDano = Color.blue;
    public float duracaoTotal = 0.6f;
    public float intervaloPiscada = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color corOriginal;
    private Coroutine coroutinePiscar;

    void Start()
    {
        vidaAtual = vidaMaxima;

        // Pega o SpriteRenderer do personagem e salva a cor original
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    public void ReceberDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log(gameObject.name + " recebeu dano! Vida atual: " + vidaAtual + " / " + vidaMaxima);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
        else
        {
            // Só pisca se o personagem ainda estiver vivo
            IniciarPiscar();
        }
    }

    private void IniciarPiscar()
    {
        if (spriteRenderer == null) return;

        if (coroutinePiscar != null)
        {
            StopCoroutine(coroutinePiscar);
        }

        coroutinePiscar = StartCoroutine(RotinaPiscarAzul());
    }

    private IEnumerator RotinaPiscarAzul()
    {
        float tempoPassado = 0f;

        while (tempoPassado < duracaoTotal)
        {
            spriteRenderer.color = corDano;
            yield return new WaitForSeconds(intervaloPiscada);

            spriteRenderer.color = corOriginal;
            yield return new WaitForSeconds(intervaloPiscada);

            tempoPassado += intervaloPiscada * 2;
        }

        spriteRenderer.color = corOriginal;
        coroutinePiscar = null;
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu definitivamente!");
        Destroy(gameObject);
        Debug.Log("Boss foi derrotado!");

        Destroy(gameObject);

        SceneManager.LoadScene("Derrota");
    }

    private void Update()
    {
        vidaPlayer.text = $"Sua vida: {vidaAtual}";
    }
}
