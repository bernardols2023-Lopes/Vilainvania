using UnityEngine;

public class ExemploReacao : MonoBehaviour
{
    // Quando o script ativa, ele se "inscreve" no QTE
    void OnEnable()
    {
        QuickTimeEvent.OnSucessoQTE += ExecutarAtaque;
        QuickTimeEvent.OnFalhaQTE += ReceberDano;
    }

    // Se o script for destruído, ele se limpa da memória
    void OnDisable()
    {
        QuickTimeEvent.OnSucessoQTE -= ExecutarAtaque;
        QuickTimeEvent.OnFalhaQTE -= ReceberDano;
    }

    void ExecutarAtaque()
    {
        Debug.Log("O QTE deu certo! O jogador atacou o monstro.");
        // Exemplo: meuAnimator.SetTrigger("Atacar");
    }

    void ReceberDano()
    {
        Debug.Log("O QTE falhou! O jogador tomou 10 de dano.");
        // Exemplo: vidaDoJogador -= 10;
    }
}