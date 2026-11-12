using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossVida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    public int vidaMinima = 100;
    private int vidaAtual;
    private int vida2;
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
        vidaAtual = vidaMaxima;
        vida2 = vidaMinima;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime;

        // Pega o SpriteRenderer do boss e salva a cor original
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    // Função pública que será chamada quando o jogador atacar o boss
    public void TomarDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtual);
        vida2 -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida2: " + vida2);

        // Verifica se a vida acabou
        if (vidaAtual <= 1)
        {
            Morrer1();
        }
        else
        {
            // Só pisca se o boss continuar vivo
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

    void Morrer1()
    {
        Debug.Log("Você derrotou o boss");

        Destroy(gameObject);

        SceneManager.LoadScene("fase 2");

        if (vida2 <= 0)
        {
            Morrer2();
        }
    }

    void Morrer2()
    {
        Debug.Log("Você derrotou o boss");

        Destroy(gameObject);

        SceneManager.LoadScene("cutscene22");
    }

    private void Update()
    {
        if (vidaBoss != null)
        {
            vidaBoss.text = $"Vida do chefe: {vida2}";
        }
    }
}
