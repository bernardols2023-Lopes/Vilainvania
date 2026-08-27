using UnityEngine;
using UnityEngine.SceneManagement;

public class atack : MonoBehaviour
{
    public float speed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnBecameInvisible() //Aciona quando o objeto com arte sai da camera
    {
        Destroy(gameObject);
    }
    //Evento acionado quando este objeto bate em outro, ou esse ou outro
    //Deve ser IsTrigger
    private void OnTriggerEnter2D(Collider2D collision)//Esse collision é o objeto que bateu
    {
        if (collision.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);//Esse destroi o inimigo quando a bala toca
            Destroy(gameObject);//Esse destroi a bala quando toca
        }
        if (collision.CompareTag("enemy2"))
        {

            Destroy(collision.gameObject);//Esse destroi o inimigo quando a bala toca
           
          
            SceneManager.LoadScene("Vitoria");
        }
    }



}