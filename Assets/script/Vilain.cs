using UnityEngine;

public class Vilain : MonoBehaviour
{
    public int Velo = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int MOVX = 0;
        int MOVY = 0;

        

        if (Input.GetKey(KeyCode.A))
        {
            MOVX = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MOVX = 1;
        }

        Vector3 moven = new Vector3(MOVX, MOVY, 0f).normalized;
        transform.position += moven * Velo * Time.deltaTime;

    }
}
