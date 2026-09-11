using UnityEngine;
using UnityEngine.SceneManagement;

public class atack : MonoBehaviour
{
    public float speed = 8;
 
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed, 0);
    }

    void Update()
    {
    }
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.CompareTag("enemy2"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
      
    }



}