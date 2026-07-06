using UnityEngine;

public class mov : MonoBehaviour
{

    public float Speed;
    public GameObject bullet;
    private Rigidbody2D rig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float InputAxis = Input.GetAxis("Horizontal");

        if (InputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        else if (InputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

    }

}