using UnityEngine;

public class mov : MonoBehaviour
{

    public float Speed;
    public GameObject bullet;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mov();


        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

    void Mov()
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