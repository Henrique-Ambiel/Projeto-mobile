using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public ItemData currentItem;  // O item atual no inventário

    private void Start()
    {
        currentItem = null;
    }
    public void AddItem(ItemData newItem)
    {
        currentItem = newItem;
    }

    public void RemoveItem()
    {
        currentItem = null;
    }
}
