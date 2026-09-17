using UnityEngine;

public class mov : MonoBehaviour
{

    public float Speed;
    public GameObject bullet;
    private Rigidbody2D rig;
    private float _timer;
    public float cooldown;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mov();

        _timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _timer >= cooldown)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            _timer = 0;
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