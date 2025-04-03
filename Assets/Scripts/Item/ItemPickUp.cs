using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemToPickup;

    public ItemInventory inventory;

    public PuzzleBooksButtons booksBt;

    public PuzzleBooks books;

    public static bool CanAnswerPuzzle = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory.currentItem == null)
            {
                inventory.AddItem(itemToPickup);
                Debug.Log($"Item {itemToPickup.itemName} adicionado ao invent�rio.");

                PlayerManager.valueBook = itemToPickup.value;

                gameObject.SetActive(false);

                AddCorrectAnswer();
                books.UpdateInventory();
                CanAnswerPuzzle = true;
            }
            
        }
    }

    void AddCorrectAnswer()
    {
        switch (PlayerManager.valueBook)
        {
            case 1:
                booksBt.correct = "C_Libras";
                break;
            case 2:
                booksBt.correct = "Y";
                break;
            case 3:
                booksBt.correct = "G";
                break;
            case 4:
                booksBt.correct = "F_Libras";
                break;
        }
    }
}