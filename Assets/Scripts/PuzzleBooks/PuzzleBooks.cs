using UnityEngine;
using UnityEngine.UI;

public class PuzzleBooks : MonoBehaviour
{
    public ItemInventory inventory; // Referência ao inventário
    public Image itemImage;      // A imagem que vai exibir o ícone do item


    private void Update()
    {
        itemImage.sprite = inventory.currentItem.itemIcon;
    }
}
