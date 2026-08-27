using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;
    [SerializeField] TMP_Text vidaPlayer;
    
    

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int quantidadeDano)
    {
        // Se estiver no frame de invencibilidade, ignora o dano totalmente
       

        vidaAtual -= quantidadeDano;
        Debug.Log(gameObject.name + " recebeu dano! Vida atual: " + vidaAtual + " / " + vidaMaxima);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
       
    }

   
    

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu definitivamente!");
        Destroy(gameObject);
        Debug.Log("Boss foi derrotado!");

        // Aqui você pode tocar uma animação de morte antes de destruir
        Destroy(gameObject);

        SceneManager.LoadScene("Derrota"); 
    }
    private void Update()
    {
        vidaPlayer.text = $"Sua vida: {vidaAtual}";
    }
}
