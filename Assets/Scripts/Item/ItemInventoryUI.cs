using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemInventory inventory; // Referência ao inventário
    public Image itemImage;      // A imagem que vai exibir o ícone do item

    void Update()
    {
        // Se houver um item no inventário, atualiza a UI
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
