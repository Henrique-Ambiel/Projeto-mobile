using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 5f;                // Velocidade do jogador
    public FixedJoystick FixedJoystick;
    public Rigidbody2D rb;                  // Referência ao Rigidbody2D do jogador

    private Vector2 currentVelocity;        // Velocidade atual do jogador
    public float smoothTime = 0.1f;         // Tempo de suavização (ajustável para controle fino)
    static public bool isMove = true;


    public void FixedUpdate()
    {
        if (isMove)
        {
            // Captura a direção de movimento com base no joystick
            Vector2 targetDirection = new Vector2(FixedJoystick.Horizontal, FixedJoystick.Vertical);

            // Se o joystick estiver sendo movido
            if (targetDirection.sqrMagnitude > 0.01f)
            {
                // Suaviza a direção do movimento (movimento suave)
                Vector2 smoothedDirection = Vector2.SmoothDamp(rb.linearVelocity, targetDirection, ref currentVelocity, smoothTime);

                // Aplica a direção suavizada no Rigidbody2D com velocidade ajustada
                rb.linearVelocity = smoothedDirection * speed;  // O speed controla a intensidade do movimento
            }
            else
            {
                // Caso o joystick não seja movido, desacelera suavemente
                rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, Vector2.zero, ref currentVelocity, smoothTime);
            }
        }
        else
        {
            // Se isMove for falso, paramos imediatamente (sem suavização)
            rb.linearVelocity = Vector2.zero;
        }
    }
}

