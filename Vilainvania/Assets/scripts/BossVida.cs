using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BossVida : MonoBehaviour
{

    [Header("Configurações de Vida")]
    public int vidaMaxima = 100;
    public int vidaMinima = 100;
    private int vidaAtual;
    private int vida2;
    [SerializeField] TMP_Text vidaBoss;
    

    void Start()
    {
        // Inicializa a vida do boss no começo do jogo
        vidaAtual = vidaMaxima;
        vida2 = vidaMinima;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime;

    }

    // Função pública que será chamada quando o jogador atacar o boss
    public void TomarDano(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida atual: " + vidaAtual);
        vida2 -= quantidadeDano;
        Debug.Log("Boss tomou dano! Vida2: " + vida2);

        // Verifica se a vida acabou
        if (vidaAtual <= 0)
        {
            Morrer();
           
             
          
        }
    }


    void Morrer1()
    {
        Debug.Log("Você derrotou o boss");

        // Aqui você pode tocar uma animação de morte antes de destruir
        Destroy(gameObject);

        SceneManager.LoadScene("fase 2");


        if  (vida2 <= 0)
        {
            Morrer2();



        }
    }
    void Morrer()
    {
        Debug.Log("Você derrotou o boss");

        // Aqui você pode tocar uma animação de morte antes de destruir
        Destroy(gameObject);

        SceneManager.LoadScene("cutscene1 1");


    }
 void Morrer2()
    {
        Debug.Log("Você derrotou o boss");

        // Aqui você pode tocar uma animação de morte antes de destruir
        Destroy(gameObject);

        SceneManager.LoadScene("Vitoria");
       
    }
 

    private void Update()
    {
        vidaBoss.text = $"Vida do chefe: {vida2}";
    }

}





