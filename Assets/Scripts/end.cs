using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject end;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            end.SetActive(true);
        }
    }
}
