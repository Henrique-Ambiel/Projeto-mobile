using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public ItemData currentItem;  // O item atual no invent�rio

    public void AddItem(ItemData newItem)
    {
        currentItem = newItem;
    }

    public void RemoveItem()
    {
        currentItem = null;
    }
}
