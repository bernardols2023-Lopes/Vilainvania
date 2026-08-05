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

    void Start()
    {
        // Inicia o ciclo de tiro assim que o jogo começa
        StartCoroutine(RotinaDeTiro());
    }

    IEnumerator RotinaDeTiro()
    {
        // Loop infinito para continuar atirando para sempre
        while (true)
        {
            // O código para aqui e espera os segundos definidos
            yield return new WaitForSeconds(tempoEntreTiros);

            // Após esperar, executa a função de disparar
            Atirar();
        }
    }

    void Atirar()
    {
        // Verifica se você não esqueceu de arrastar os objetos no Unity
        if (prefabBala != null && pontoDeDisparo != null)
        {
            // Cria a cópia da bala na posição e rotação exatas do ponto de disparo
            Instantiate(prefabBala, pontoDeDisparo.position, pontoDeDisparo.rotation);
        }
        else
        {
            Debug.LogWarning("Por favor, atribua o Prefab da Bala e o Ponto de Disparo no Inspector do Boss!");
        }
    }
}
