using UnityEngine;

public class MovimentoBala : MonoBehaviour
{
    [Header("Configurações do Projétil")]
    public float velocidade = 10f;
    public float tempoDeVida = 5f; 

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}
