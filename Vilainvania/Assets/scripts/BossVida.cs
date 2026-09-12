using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossVida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    public int vidaMinima = 100;
    private int vidaAtuais;
    private int vidaMinimaAtuais;
    [SerializeField] TMP_Text vidaBoss;

    void Start()
    {

        vidaAtuais = vidaMaxima;
        vidaMinima = vidaMaxima;
    }


    public void TonarDano(int quantidadeDano)
    {
        vidaAtuais -= quantidadeDano;
        vidaMinima -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtuais);
        Debug.Log("Boss tomou dano! Vida atual: " + vidaMinima);



        if (vidaAtuais <= 1)
        {
           Morrer1();
        }
    }

    void Morrer1()
    {
        Debug.Log("Você derrotou o boss");

        SceneManager.LoadScene("fase 2");
        if (vidaAtuais <= 0) 
        {
            Morrer2();
        
        }
    }
    void Morrer2()
    {
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
