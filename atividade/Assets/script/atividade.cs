using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class atividade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int jogos = 3;
        if (jogos > 3)
        {
            Debug.Log("não tem jogos suficiente");
            
        }
        else if (jogos == 3)
        {
            Debug.Log("acabou de atingir os jogos para entrar");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
