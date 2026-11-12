using System.Collections;
using UnityEngine;

public class PiscarDano_2 : MonoBehaviour
{
    [Header("Configurações do Efeito")]
    [Tooltip("Cor roxa que o personagem vai piscar")]
    public Color corDano = new Color(0.5f, 0f, 0.5f, 1f);

    [Tooltip("Duração total do efeito em segundos")]
    public float duracaoTotal = 0.6f;

    [Tooltip("Tempo de cada piscada")]
    public float intervaloPiscada = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color corOriginal;
    private Coroutine coroutinePiscar;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    public void TomarDano()
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
}
