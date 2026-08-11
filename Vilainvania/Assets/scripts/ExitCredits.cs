using UnityEngine;
using UnityEngine.SceneManagement; // Permite mudar de cena

public class ExitCredits : MonoBehaviour
{
    // Digite aqui o nome exato da sua cena principal ou menu
    public string cenaDeRetorno = "Menu";

    // Função que será ativada ao clicar no botão
    public void Voltar()
    {
        SceneManager.LoadScene(cenaDeRetorno);
    }
}
