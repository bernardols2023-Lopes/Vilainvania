using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configurações")]
    public Transform playerTransform;
    public float offsetX = 2.0f;     

    private float initialY;
    private float initialZ;

    void Start()
    {
       
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
          
            float targetX = playerTransform.position.x + offsetX;

            
            transform.position = new Vector3(targetX, initialY, initialZ);
        }
    }
}
