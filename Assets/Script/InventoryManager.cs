using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<SlotClass> items = new List<SlotClass>();
    public List<SlotClass> hotbarItems = new List<SlotClass>();
    public GameObject inventoryPanel;

    public InventoryUIHandler inventoryUI;
    public InventoryUIHandler hotbarUI;
    private bool isInventoryOpen = false;
    void Start()
    {
        inventoryUI.Init();
        hotbarUI.Init();
        RefreshAllUI();
    }

    public void AddItem(ItemClass item)
    {

        SlotClass slot = Contains(item);
        if(slot != null)
        {
            slot.SetQuantity(1);
        }
        else
        {
            items.Add(new SlotClass(item, 1));
        }
        RefreshAllUI();
        //if (item != null)
        //{
        //    items.Add(item);
        //    Debug.Log("Item added: " + item.itemName);

        //    if (isInventoryOpen)
        //        RefreshAllUI();
        //}
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryPanel.SetActive(isInventoryOpen);

            // Nếu bật thì cập nhật UI
            if (isInventoryOpen)
            {
                RefreshAllUI();
            }
        }
    }

    public void RemoveItem(ItemClass item)
    {
        SlotClass slotToRemove = new SlotClass();
        foreach (SlotClass slot in items)
        {
            if(slot.GetItem()==item)
            {
                slotToRemove= slot;
                break;
            }
        }
        items.Remove(slotToRemove);
        RefreshAllUI();
        //if (item != null && items.Contains(item))
        //{
        //    items.Remove(item);
        //    Debug.Log("Item removed: " + item.itemName);
        //    RefreshAllUI();
        //}
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if(slot.GetItem()==item)
            {
                return slot;
            }
        }
        return null;
    }

    private void RefreshAllUI()
    {
        inventoryUI.RefreshUI(items);
        hotbarUI.RefreshUI(hotbarItems.Count > 0 ? hotbarItems : items); 
    }
}
