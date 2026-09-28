using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configurações")]
    public Transform playerTransform; // Arraste o Player aqui no Inspector
    public float offsetX = 2.0f;      // Distância horizontal entre a câmera e o player

    private float initialY;
    private float initialZ;

    void Start()
    {
        // Salva as posições iniciais de Y e Z da câmera para que elas não mudem
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Atualiza apenas o eixo X baseado na posição do player + o deslocamento (offset)
            float targetX = playerTransform.position.x + offsetX;

            // Aplica a nova posição mantendo Y e Z fixos
            transform.position = new Vector3(targetX, initialY, initialZ);
        }
    }
}
