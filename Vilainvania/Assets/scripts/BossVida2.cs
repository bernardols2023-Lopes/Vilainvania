using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossVida2 : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    private int vidaAtuais;
    [SerializeField] TMP_Text vidaBoss;

    [Header("Configurações de Piscar")]
    public Color corDano = new Color(0.5f, 0f, 0.5f, 1f); // Roxo
    public float duracaoTotal = 0.6f;
    public float intervaloPiscada = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color corOriginal;
    private Coroutine coroutinePiscar;

    void Start()
    {
        vidaAtuais = vidaMaxima;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    public void TonarDano(int quantidadeDano)
    {
        vidaAtuais -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtuais);

        if (vidaAtuais <= 0)
        {
            Vitoria1();
        }
        else
        {
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

        coroutinePiscar = StartCoroutine(RotinaPiscarRoxo());
    }

    private IEnumerator RotinaPiscarRoxo()
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

    void Vitoria1()
    {
        Debug.Log("Você derrotou o boss");

        SceneManager.LoadScene("Vitoria");
    }

    private void Update()
    {
        if (vidaBoss != null)
        {
            vidaBoss.text = $"Vida do chefe: {vidaAtuais}";
        }
    }
}
