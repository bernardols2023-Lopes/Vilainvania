using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss_Vida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    private int vidaAtual;

    [SerializeField] private TMP_Text vidaBoss;
    [SerializeField] private string tagDoTiro = "TiroHeroi";

    
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    private void Update()
    {
        if (vidaBoss != null)
        {
            vidaBoss.text = $"Vida do chefe: {vidaAtual}";
        }
    }

    //detecta o tiro do herói através da tag
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagDoTiro))
        {
            TomarDano(20);
            Destroy(other.gameObject);
        }
    }

    
    public void TomarDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }


    void Morrer()
    {
        Debug.Log("Você derrotou o boss");

        SceneManager.LoadScene("cutscene0");

        Destroy(gameObject);
    }
}
