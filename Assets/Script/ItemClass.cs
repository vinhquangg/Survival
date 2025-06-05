using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass:ScriptableObject
{ 
    public ItemType itemType = ItemType.None;
    public string itemName;
    public Sprite itemIcon;

    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscClass GetMisc();
    public abstract Consumable GetConsumable();

    public abstract float GetDurability();
}
