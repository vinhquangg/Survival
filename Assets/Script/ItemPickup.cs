using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
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

    public void Interact()
    {
        Debug.Log("Adding item to inventory: ");
        gameObject.SetActive(false);
    }


}
