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
        
        Vida scriptVida = alvo.GetComponent<Vida>();
        if (scriptVida != null)
        {
            scriptVida.ReceberDano(quantidadeDano);
        }

        BossVida scriptBossAntigo = alvo.GetComponent<BossVida>();
        if (scriptBossAntigo != null)
        {
            scriptBossAntigo.TomarDano(quantidadeDano);
        }

        BossVida2 scriptBossNovo = alvo.GetComponent<BossVida2>();
        if (scriptBossNovo != null)
        {
            scriptBossNovo.TonarDano(quantidadeDano);
        }

        if (destruirAoColidir)
        {
            Destroy(gameObject);
        }
    }
}
