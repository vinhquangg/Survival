using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public ItemClass itemdata;
    private InteractableObject InteractableObject;
    private void Start()
    {
        InteractableObject = GetComponent<InteractableObject>();
        if (InteractableObject == null)
        {
            Debug.LogError("ItemPickup requires an InteractableObject component.");
        }
    }
    public string GetItemName()
    {
        return InteractableObject.GetItemName();
    }

    public string GetItemType()
    {
        return InteractableObject.GetItemType();
    }

    //public void Interact()
    //{
    //    if (inventory != null)
    //    {
    //        inventory.AddItem(itemdata);
    //        //Destroy(gameObject); // Xoá object khỏi scene sau khi nhặt
    //        gameObject.SetActive(false);
    //    }
    //}

    public void Interact(GameObject interactor)
    {
        var inventory = interactor.GetComponentInChildren<InventoryManager>();
        if (inventory != null && itemdata != null)
        {
            inventory.AddItem(itemdata);
            Destroy(gameObject);
        }
    }
}
