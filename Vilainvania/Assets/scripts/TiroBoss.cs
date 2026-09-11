using System.Collections;
using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    [Header("Configurações do Tiro")]
    [Tooltip("Arraste o Prefab da sua bala/laser aqui")]
    public GameObject prefabBala;

    [Tooltip("Arraste o objeto que fica na ponta da arma aqui")]
    public Transform pontoDeDisparo;

    [Tooltip("Tempo em segundos entre cada disparo")]
    public float tempoEntreTiros = 2.0f;

    [Header("Configurações de Áudio")]
    [Tooltip("Arraste o componente AudioSource do Boss aqui")]
    public AudioSource audioSource;

    [Tooltip("Arraste o som de tiro do Boss aqui")]
    public AudioClip somTiro;

    void Start()
    {
        StartCoroutine(RotinaDeTiro());
    }

    IEnumerator RotinaDeTiro()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempoEntreTiros);

            Atirar();
        }
    }

    void Atirar()
    {
        if (prefabBala != null && pontoDeDisparo != null)
        {
            Instantiate(prefabBala, pontoDeDisparo.position, pontoDeDisparo.rotation);

            if (audioSource != null && somTiro != null)
            {
                audioSource.PlayOneShot(somTiro);
            }
        }
        else
        {
            Debug.LogWarning("Por favor, atribua o Prefab da Bala e o Ponto de Disparo no Inspector do Boss!");
        }
    }
}
