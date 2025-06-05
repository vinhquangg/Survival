using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIHandler : MonoBehaviour
{
    public GameObject slotHolder; 
    private GameObject[] slots;

    public void Init()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    public void RefreshUI(List<SlotClass> slots)
    {
        for (int i = 0; i < this.slots.Length; i++)
        {
            var image = this.slots[i].transform.GetChild(0).GetComponent<Image>();
            var text = this.slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            var slider = this.slots[i].transform.GetChild(2).GetComponent<Slider>();

            if (i < slots.Count && !slots[i].IsEmpty())
            {
                var slot = slots[i];
                var item = slot.GetItem();

                image.sprite = item.itemIcon;
                image.enabled = true;

                if (slot.IsTool())
                {
                    slider.gameObject.SetActive(true);
                    slider.value = slot.GetDurability();
                    text.text = "";
                    text.gameObject.SetActive(false);
                }
                else
                {
                    slider.gameObject.SetActive(false);
                    text.text = slot.GetQuantity().ToString();
                    text.gameObject.SetActive(true);
                }
            }
            else
            {
                image.sprite = null;
                image.enabled = false;
                text.text = "";
                text.gameObject.SetActive(true);
                slider.gameObject.SetActive(false);
            }
        }
    }



}
