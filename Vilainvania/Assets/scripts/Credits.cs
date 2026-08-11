using UnityEngine;

public class Credits : MonoBehaviour
{
    public int velocidade = 50;

    void Update()
    {
        // Faz o texto subir continuamente
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    // Reinicia a posição do texto lá embaixo sempre que abrir a tela
    void OnEnable()
    {
        transform.localPosition = new Vector3(0, -600, 0);
    }
}
