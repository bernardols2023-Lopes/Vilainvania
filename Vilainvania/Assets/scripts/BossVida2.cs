using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossVida2 : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    private int vidaAtuais;
    [SerializeField] TMP_Text vidaBoss;

    void Start()
    {
        // Inicializa a vida do boss no começo do jogo
        vidaAtuais = vidaMaxima;
    }

    // Mantido o nome original com 'n' para o jogador conseguir dar dano
    public void TonarDano(int quantidadeDano)
    {
        vidaAtuais -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtuais);

        // Verifica se a vida acabou
        if (vidaAtuais <= 0)
        {
            Vitoria1();
        }
    }

    void Vitoria1()
    {
        Debug.Log("Você derrotou o boss");

        // MUDANÇA DE CENA
        SceneManager.LoadScene("Vitoria 1");
    }

    private void Update()
    {
        if (vidaBoss != null)
        {
            vidaBoss.text = $"Vida do chefe: {vidaAtuais}";
        }
    }
}
