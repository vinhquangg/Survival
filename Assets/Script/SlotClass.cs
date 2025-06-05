using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotClass
{
    private ItemClass item;
    private int quantity;
    private float durability;
    
    public SlotClass()
    {
        item = null;
        quantity = 0;
        durability = 0;
    }

    public SlotClass(ItemClass _item, int _quantity)
    {
        item= _item;
        quantity= _quantity;

        if (item is ToolClass tool)
            durability = tool.durability; 
        else
            durability = -1f; 
    }

    public ItemClass GetItem() { return item; }
    public int GetQuantity() { return quantity; }

    // Getters
    //public ItemClass GetItem() => item;
    //public int GetQuantity() => quantity;
    public float GetDurability() => durability;

    // Setters
    public void SetItem(ItemClass newItem) => item = newItem;
    public void SetQuantity(int newQty) => quantity += newQty;
    public void SetDurability(float value) => durability = Mathf.Clamp01(value);

    public bool IsEmpty() => item == null;
    public bool IsTool() => item != null && item.itemType == ItemType.Tool;
}
