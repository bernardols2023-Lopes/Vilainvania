using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GerenciadorQTE : MonoBehaviour
{
    [Header("Configurações do QTE")]
    [SerializeField] private KeyCode teclaEsperada = KeyCode.E;
    [SerializeField] private float tempoLimite = 2.0f;

    [Header("Componentes de Interface (UI)")]
    [SerializeField] private GameObject painelQTE;
    [SerializeField] private Text textoBotao;
    [SerializeField] private Image barraProgresso;

    [Header("Eventos do Jogo")]
    public UnityEvent aoAcertar;
    public UnityEvent aoFalhar;

    private float tempoRestante;
    private bool qteAtivo = false;

    void Start()
    {
        // Garante que o QTE comece escondido
        if (painelQTE != null) painelQTE.SetActive(false);
    }

    void Update()
    {
        if (!qteAtivo) return;

        // Atualiza o temporizador
        tempoRestante -= Time.deltaTime;

        // Atualiza a barra visual (UI) se ela existir
        if (barraProgresso != null)
        {
            barraProgresso.fillAmount = tempoRestante / tempoLimite;
        }

        // Verifica a resposta do jogador
        if (Input.GetKeyDown(teclaEsperada))
        {
            Sucesso();
        }
        else if (tempoRestante <= 0)
        {
            Falha();
        }
    }

    // Chame esta função de qualquer outro script para iniciar o evento
    public void IniciarQTE()
    {
        qteAtivo = true;
        tempoRestante = tempoLimite;

        if (textoBotao != null) textoBotao.text = teclaEsperada.ToString();
        if (painelQTE != null) painelQTE.SetActive(true);
    }

    private void Sucesso()
    {
        FinalizarQTE();
        aoAcertar.Invoke();
    }

    private void Falha()
    {
        FinalizarQTE();
        aoFalhar.Invoke();
    }

    private void FinalizarQTE()
    {
        qteAtivo = false;
        if (painelQTE != null) painelQTE.SetActive(false);
    }
}