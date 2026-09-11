using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    public string cenaDeRetorno = "Menu";

    public void Voltar()
    {
        SceneManager.LoadScene(cenaDeRetorno);
    }
}
