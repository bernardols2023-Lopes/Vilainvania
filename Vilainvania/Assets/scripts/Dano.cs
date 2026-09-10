using UnityEngine;

public class Dano : MonoBehaviour
{
    public int quantidadeDano = 20;

    [Header("Configuração de Alvo")]
    public string tagDoAlvo = "Inimigo";
    public string TagDoAlvo = "enemy2";

    [Header("Opções do Projétil")]
    [Tooltip("Marque se este objeto for um tiro, flecha ou magia que deve sumir após acertar o alvo")]
    public bool destruirAoColidir = true;

    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag(tagDoAlvo))
        {
            AplicarDano(colisao.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.CompareTag(tagDoAlvo))
        {
            AplicarDano(colisao.gameObject);
        }
    }

    private void AplicarDano(GameObject alvo)
    {
        // 1. Tenta dar dano se o alvo usar o script de Vida comum
        Vida scriptVida = alvo.GetComponent<Vida>();
        if (scriptVida != null)
        {
            scriptVida.ReceberDano(quantidadeDano);
        }

        // 2. CORRIGIDO: Agora procura por BossVida2 e chama TonarDano
        BossVida2 scriptBoss = alvo.GetComponent<BossVida2>();
        if (scriptBoss != null)
        {
            scriptBoss.TonarDano(quantidadeDano);
        }

        // Se for um tiro, destrói o próprio tiro para não dar dano repetido
        if (destruirAoColidir)
        {
            Destroy(gameObject);
        }
    }
}
