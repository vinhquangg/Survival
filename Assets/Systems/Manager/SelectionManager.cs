using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    public float interactionDistance;
    public GameObject interaction_Info;
    public GameObject interaction_Type;
    public GameObject cursor;
    public LayerMask interactableLayer;
    TextMeshProUGUI interact_text;
    TextMeshProUGUI interact_type;
    void Start()
    {
        interact_text= interaction_Info.GetComponent<TextMeshProUGUI>();
        interact_type = interaction_Type.GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, interactableLayer))
        {
            var selectionTransform = hit.transform;

            var interactable = selectionTransform.GetComponent<InteractableObject>();
            if (interactable)
            {
                float distance = Vector3.Distance(Camera.main.transform.position, hit.point);
                if (distance <= interactionDistance)
                {
                    ShowInteractionUI(interactable.GetItemName(), interactable.GetItemType());
                }
                else
                {
                    HideInteractionUI();
                }
            }
            else
            {
                HideInteractionUI();
            }
        }
        else
        {
            HideInteractionUI();
        }
    }


    void ShowInteractionUI(string name, string type)
    {
        interact_text.text = name;
        interact_type.text = type;
        cursor.SetActive(false);
        interaction_Info.SetActive(true);
        interaction_Type.SetActive(true);
    }

    void HideInteractionUI()
    {
        cursor.SetActive(true);
        interaction_Info.SetActive(false);
        interaction_Type.SetActive(false);
    }
}
