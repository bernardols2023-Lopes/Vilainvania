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
        if (vidaAtual <= 1)
        {
            Morrer1();
           
             
          
        }
    }


    void Morrer1()
    {
        Debug.Log("Você derrotou o boss");

        
        Destroy(gameObject);

        SceneManager.LoadScene("fase 2");


        if  (vida2 <= 0)
        {
            Morrer2();



        }
    }
 void Morrer2()
    {
        Debug.Log("Você derrotou o boss");

        
        Destroy(gameObject);

        SceneManager.LoadScene("Vitoria");
       
    }
 

    private void Update()
    {
        vidaBoss.text = $"Vida do chefe: {vidaAtual}";
    }

}





