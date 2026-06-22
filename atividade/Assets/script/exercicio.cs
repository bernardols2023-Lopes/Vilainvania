using UnityEngine;
using TMPro;
using System;
public class ExercicioTexto : MonoBehaviour
{
    [SerializeField] TMP_InputField nomeInput;
    [SerializeField] TMP_InputField idadeInput;
    [SerializeField] TMP_Text textoUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Acessar()
    {
        string nome = nomeInput.text;
        string idade = idadeInput.text;

        if (idade.Length == 0 || nome.Length == 0)
        {
            textoUI.text = "Nome e idade são obrigatórios";
            Debug.Log("Nome e idade são obrigatórios");
        }
        else
        {
            Debug.Log($"Seu nome é {nome}");
            char[] letras = nome.ToCharArray();
            Array.Reverse(letras);
            Debug.Log($"Seu nome invertido é {new string(letras)}");

            if (nome.Contains(" "))
            {
                Debug.Log($"Seu nome contem espaços");
            }
            else
            {
                Debug.Log($"Seu nome não contem espaços");
            }
            Debug.Log($"Seu nome tem {nome.Length} letras");
            Debug.Log($"A primeira letra é {nome[0]}");
            Debug.Log($"A ultima letra é {nome[nome.Length - 1]}");
        }
    }
}
