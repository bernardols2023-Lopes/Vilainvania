using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossVida2 : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    private int vidaAtuais;
    [SerializeField] TMP_Text vidaBoss;

    // Apenas criamos a referência para o Animator aqui
    private Animator anim;

    void Start()
    {
        vidaAtuais = vidaMaxima;

        // Pegamos o componente Animator do Boss ao iniciar
        anim = GetComponent<Animator>();
    }

    public void TonarDano(int quantidadeDano)
    {
        vidaAtuais -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtuais);

        // ESSA É A ÚNICA LINHA NOVA: Ela ativa a animação Hurt quando ele toma dano!
        if (anim != null) anim.SetTrigger("hurt");

        if (vidaAtuais <= 0)
        {
            Vitoria1();
        }
    }

    void Vitoria1()
    {
        Debug.Log("Você derrotou o boss");

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
