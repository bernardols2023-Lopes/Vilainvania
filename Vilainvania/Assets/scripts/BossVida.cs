using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BossVida : MonoBehaviour
{

    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    private int vidaAtual;
    [SerializeField] TextMeshPro vidaBoss;
    

    void Start()
    {
        // Inicializa a vida do boss no começo do jogo
        vidaAtual = vidaMaxima;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime;

    }

    // Função pública que será chamada quando o jogador atacar o boss
    public void TomarDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtual);

        // Verifica se a vida acabou
        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Boss foi derrotado!");

        // Aqui você pode tocar uma animação de morte antes de destruir
        Destroy(gameObject);

        SceneManager.LoadScene("Vitoria");
    }
    private void Update()
    {
        
    }

}
