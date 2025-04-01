using UnityEngine;
using UnityEngine.UI;

public class PuzzleBooks : MonoBehaviour
{
    public ItemInventory inventory; // Refer�ncia ao invent�rio
    public Image itemImage;      // A imagem que vai exibir o �cone do item


    private void Update()
    {
        itemImage.sprite = inventory.currentItem.itemIcon;
    }
}
