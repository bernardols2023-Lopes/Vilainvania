using System.Collections;
using UnityEngine;

public class PiscarDano : MonoBehaviour
{
    [Header("Configurações do Efeito")]
    [Tooltip("Cor que o personagem vai piscar")]
    public Color corDano = Color.blue;

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
}
