using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemClass itemToAdd;
    public ItemClass itemToremove;

    public List<ItemClass> inventory = new List<ItemClass>();

    private void Start()
    {
        AddItem(itemToAdd);
        RemoveItem(itemToremove);
    }
    
    public void AddItem(ItemClass item)
    {
        if (item != null)
        {
            inventory.Add(item);
            Debug.Log("Item added: " + item.itemName);
        }
        else
        {
            Debug.LogWarning("Attempted to add a null item.");
        }
    }

    public void RemoveItem(ItemClass item)
    {
        if (item != null && inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log("Item removed: " + item.itemName);
        }
        else
        {
            Debug.LogWarning("Attempted to remove an item that is not in the inventory or is null.");
        }
    }
}
