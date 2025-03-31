using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 5f;                // Velocidade do jogador
    public FixedJoystick FixedJoystick;
    public Rigidbody2D rb;                  // Referência ao Rigidbody2D do jogador

    private Vector2 currentVelocity;        // Velocidade atual do jogador

    // A função FixedUpdate() é chamada para aplicar movimento suave ao jogador
    public void FixedUpdate()
    {
        // Captura a direção de movimento com base no joystick
        Vector2 targetDirection = new Vector2(FixedJoystick.Horizontal, FixedJoystick.Vertical);

        // Se o joystick estiver sendo movido, interpolamos a direção e a velocidade
        if (targetDirection.sqrMagnitude > 0.01f)
        {
            // Suaviza o movimento da direção (movimento suave)
            Vector2 smoothedDirection = Vector2.SmoothDamp(rb.linearVelocity, targetDirection, ref currentVelocity, 0.1f);

            // Aplica a direção suavizada no Rigidbody2D
            rb.linearVelocity = smoothedDirection * speed;  // O speed controla a intensidade do movimento
        }
        else
        {
            // Caso o joystick não seja movido, para o movimento (parada suave)
            rb.linearVelocity = Vector2.zero;
        }
    }
}
