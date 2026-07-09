using UnityEngine;
using System;


public class VidaDoPersonagem : MonoBehaviour
{
    [Header("Configurações de Vida")]
    [SerializeField] private int vidaMaxima = 100;

    // Propriedades auto-implementadas (protegem a variável de modificações externas diretas)
    public int VidaMaxima => vidaMaxima;
    public int VidaAtual { get; private set; }

    // Eventos que outros scripts (como UI de Barra de Vida) podem "escutar"
    public static event Action OnJogadorMorreu; // Evento global/estático caso seja o jogador principal
    public event Action<int, int> OnVidaAlterada; // Passa (vidaAtual, vidaMaxima) para atualizar barras de vida

    void Start()
    {
        VidaAtual = vidaMaxima;
        // Notifica o estado inicial da vida
        OnVidaAlterada?.Invoke(VidaAtual, vidaMaxima);
    }

    public void TomarDano(int quantidadeDano)
    {
        // Evita processar dano se o personagem já estiver morto
        if (VidaAtual <= 0) return;

        VidaAtual -= quantidadeDano;
        VidaAtual = Mathf.Clamp(VidaAtual, 0, vidaMaxima);

        // Dispara o evento de que a vida mudou
        OnVidaAlterada?.Invoke(VidaAtual, vidaMaxima);

        if (VidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void Curar(int quantidadeCura)
    {
        if (VidaAtual <= 0) return; // Não cura se já morreu

        VidaAtual += quantidadeCura;
        VidaAtual = Mathf.Clamp(VidaAtual, 0, vidaMaxima);

        OnVidaAlterada?.Invoke(VidaAtual, vidaMaxima);
    }

    private void Morrer()
    {
        // Se este objeto for o Jogador, avisa o resto do jogo (útil para telas de Game Over)
        if (gameObject.CompareTag("Player"))
        {
            OnJogadorMorreu?.Invoke();
        }

        // Lógica de morte (ex: desativar scripts, tocar animação)
        // Em vez de destruir imediatamente, desativamos para evitar bugs visuais bruscos
        gameObject.SetActive(false);
    }
}