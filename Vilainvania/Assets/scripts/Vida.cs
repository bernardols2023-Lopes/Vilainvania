using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;

    private bool estaInvencivel = false;
    public float tempoInvencibilidade = 0.2f; // Tempo para aceitar o próximo dano

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int quantidadeDano)
    {
        // Se estiver no frame de invencibilidade, ignora o dano totalmente
        if (estaInvencivel) return;

        vidaAtual -= quantidadeDano;
        Debug.Log(gameObject.name + " recebeu dano! Vida atual: " + vidaAtual + " / " + vidaMaxima);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
        else
        {
            // Ativa a proteção temporária contra múltiplos acertos seguidos
            StartCoroutine(AtivarInvencibilidade());
        }
    }

    private IEnumerator AtivarInvencibilidade()
    {
        estaInvencivel = true;
        yield return new WaitForSeconds(tempoInvencibilidade);
        estaInvencivel = false;
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
}
