using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemToPickup;  // O item que ser� coletado

    public ItemInventory inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Adiciona o item ao invent�rio
            inventory.AddItem(itemToPickup);
            Debug.Log($"Item {itemToPickup.itemName} adicionado ao invent�rio.");

            PlayerManager.valueBook = itemToPickup.value;

            gameObject.SetActive(false);
        }
    }
}