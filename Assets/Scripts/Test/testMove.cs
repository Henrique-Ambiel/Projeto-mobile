using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimenta��o
    public float rotationSpeed = 700f; // Velocidade de rota��o (se necess�rio)

    private Rigidbody2D rb;

    void Start()
    {
        // Obt�m o Rigidbody2D do jogador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtendo a entrada de movimento horizontal e vertical (WASD ou setas)
        float moveX = Input.GetAxisRaw("Horizontal"); // -1 a 1 (A/D ou setas)
        float moveY = Input.GetAxisRaw("Vertical"); // -1 a 1 (W/S ou setas)

        // Calculando a dire��o com base nas entradas
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Aplicando movimento no Rigidbody2D
        rb.linearVelocity = moveDirection * moveSpeed;

        // Opcional: se voc� quiser que o jogador sempre "olhe" para a dire��o do movimento
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.deltaTime);
        }
    }
}
