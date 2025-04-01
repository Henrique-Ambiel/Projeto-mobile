using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemToPickup;  // O item que será coletado

    public ItemInventory inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Adiciona o item ao inventário
            inventory.AddItem(itemToPickup);
            Debug.Log($"Item {itemToPickup.itemName} adicionado ao inventário.");

            PlayerManager.valueBook = itemToPickup.value;

            gameObject.SetActive(false);
        }
    }
}