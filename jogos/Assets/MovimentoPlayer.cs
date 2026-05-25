using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    [Header("Configurações")]
    public float velocidade = 5f; // Velocidade de andar
    public float sensibilidadeMouse = 2f; // Velocidade de olhar
    public Transform cameraJogador; // A câmera para olhar para cima/baixo

    private float rotacaoX = 0f;

    void Start()
    {
        // Trava a setinha do mouse no centro da tela e esconde ela
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // --- 1. ANDAR (Teclas WASD ou Setas) ---
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movimento = transform.right * moveX + transform.forward * moveZ;
        transform.position += movimento * velocidade * Time.deltaTime;

        // --- 2. OLHAR (Mouse) ---
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // Gira o corpo do Player para os lados (Esquerda/Direita)
        transform.Rotate(Vector3.up * mouseX);

        // Gira apenas a Câmera para cima e para baixo
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Trava para não quebrar o pescoço
        cameraJogador.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
    }
}