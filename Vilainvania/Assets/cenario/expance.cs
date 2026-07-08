using System;

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour

{

    [Header("Configurações do QTE")]

    [Tooltip("Lista de teclas possíveis para o QTE escolher uma aleatória")]

    public List<KeyCode> teclasPossiveis = new List<KeyCode> { KeyCode.E, KeyCode.Q, KeyCode.F, KeyCode.Space };

    public float tempoLimite = 2.0f;

    [Header("Componentes de UI")]

    public Text textoInstrucao;

    public Slider barraTempo;

    // Eventos para outros scripts se conectarem

    public static event Action OnSucessoQTE;

    public static event Action OnFalhaQTE;

    private KeyCode teclaAtual;

    private bool qteAtivo = false;

    private float tempoRestante;

    void Start()

    {

        // Teste automático após 2 segundos

        Invoke("IniciarQTEAleatorio", 2f);

    }

    void Update()

    {

        if (!qteAtivo) return;

        // Contador de tempo

        tempoRestante -= Time.deltaTime;

        if (barraTempo != null)

        {

            barraTempo.value = tempoRestante / tempoLimite;

        }

        if (tempoRestante <= 0)

        {

            FinalizarQTE(false);

        }

        // Verifica a tecla sorteada

        if (Input.GetKeyDown(teclaAtual))

        {

            FinalizarQTE(true);

        }

        // Se apertar qualquer OUTRA tecla, conta como falha imediata

        else if (Input.anyKeyDown)

        {

            FinalizarQTE(false);

        }

    }

    public void IniciarQTEAleatorio()

    {

        if (teclasPossiveis.Count == 0)

        {

            Debug.LogError("Adicione teclas na lista do Inspector!");

            return;

        }

        // Sorteia uma tecla da lista

        int indiceAleatorio = UnityEngine.Random.Range(0, teclasPossiveis.Count);

        teclaAtual = teclasPossiveis[indiceAleatorio];

        tempoRestante = tempoLimite;

        qteAtivo = true;

        if (textoInstrucao != null) textoInstrucao.text = $"APERTE {teclaAtual.ToString()}!";

        if (barraTempo != null) barraTempo.gameObject.SetActive(true);

    }

    private void FinalizarQTE(bool acertou)

    {

        qteAtivo = false;

        if (barraTempo != null) barraTempo.gameObject.SetActive(false);

        if (acertou)

        {

            if (textoInstrucao != null) textoInstrucao.text = "SUCESSO!";

            OnSucessoQTE?.Invoke(); // Avisa o jogo que o jogador acertou

        }

        else

        {

            if (textoInstrucao != null) textoInstrucao.text = "FALHOU!";

            OnFalhaQTE?.Invoke(); // Avisa o jogo que o jogador errou

        }

    }

}
 

