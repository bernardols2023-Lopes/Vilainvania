using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para manipular cenas

public class MenuPrincipal : MonoBehaviour
{
    // Função pública para ser chamada pelo botão
    public void MudarCena(string Emanuel)
    {
        SceneManager.LoadScene(Emanuel);
    }
}
