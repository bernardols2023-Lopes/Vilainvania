using UnityEngine;

public class MovimentoBala : MonoBehaviour
{
    [Header("Configurações do Projétil")]
    public float velocidade = 10f;
    public float tempoDeVida = 5f; // Destrói a bala após 5 segundos para não travar o jogo

    void Start()
    {
        // Garante que a bala seja destruída depois de um tempo para poupar memória
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Move a bala para a frente (eixo X positivo do objeto) a cada frame
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}
