using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemInventory inventory; // Refer�ncia ao invent�rio
    public Image itemImage;      // A imagem que vai exibir o �cone do item

    void Update()
    {
        // Se houver um item no invent�rio, atualiza a UI
        if (inventory.currentItem != null)
        {
            itemImage.sprite = inventory.currentItem.itemIcon;
            itemImage.enabled = true;  // Exibe a imagem
        }
        else
        {
            itemImage.enabled = false;  // Esconde a imagem
        }
    }
}
