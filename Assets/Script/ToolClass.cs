using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewTool", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    public ToolType toolType;
    public ToolClass()
    {
        itemType = ItemType.Tool;
        itemName = "Tool";
        itemIcon = null; // Assign a default icon or leave it null
        toolType = ToolType.None;
    }

    public enum ToolType
    {
        None = 0,
        Hammer = 1,
        Axe = 2,
        Pickaxe = 3,
        Shovel = 4,
        FishingRod = 5
    }
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override Consumable GetConsumable() { return null; }

}
