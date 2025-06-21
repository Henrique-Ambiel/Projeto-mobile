using UnityEngine;

public class ManagerDoor : MonoBehaviour
{
    public string keyCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KeyM"))
        {
            keyCode = "m";
            Debug.Log("chave m pega");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("KeyS"))
        {
            keyCode = "s";
            Debug.Log("chave s pega");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("KeyA"))
        {
            keyCode = "a";
            Debug.Log("chave a pega");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("KeyQ"))
        {
            keyCode = "q";
            Debug.Log("chave q pega");
            Destroy(collision.gameObject);
        }
    }
}
