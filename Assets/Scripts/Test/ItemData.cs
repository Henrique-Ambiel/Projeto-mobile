using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;  // Imagem do item
    public int value;
}