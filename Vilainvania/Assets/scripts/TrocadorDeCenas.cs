using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocadorDeCenas : MonoBehaviour
{

    public void IrParaCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }


    // Aqui é pra caso vc quiser ter um de kitar
    public void SairDoJogo()
    {
        Debug.Log("you quit the game");

        Application.Quit();
    }
}