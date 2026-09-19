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
        
        vidaAtuais = vidaMaxima;
    }

    
    public void TonarDano(int quantidadeDano)
    {
        vidaAtuais -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtuais);

        
        if (vidaAtuais <= 0)
        {
            Vitoria1();
        }
    }

    void Vitoria1()
    {
        Debug.Log("Você derrotou o boss");

       
        SceneManager.LoadScene("Vitoria");
    }

    private void Update()
    {
        if (vidaBoss != null)
        {
            vidaBoss.text = $"Vida do chefe: {vidaAtuais}";
        }
    }
}
