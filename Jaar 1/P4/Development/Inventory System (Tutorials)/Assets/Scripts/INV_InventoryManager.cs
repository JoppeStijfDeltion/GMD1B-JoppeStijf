using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class INV_InventoryManager : MonoBehaviour, IHasChanged {

    //staat op het Canvas
    //transform slots staat op het eerste inventory slot panel
    [SerializeField] Transform slots;
    [SerializeField] Text inventoryText;

    public Item itemScript;
    public Color textColor;

    public GameObject inventorySwitch;
    public bool inventoryActive;
    public float inventoryActiveTimer;

    public void Start()
    {
        //inv_DragHandelerScript = gameObject.GetComponent<Item>().itemID;
        inventorySwitch.SetActive(false);
        HasChanged();
    }

    public void Update()
    {
        if (inventorySwitch.activeSelf && Input.GetButtonDown("Jump"))
        {
            inventoryActive = true;
        }

        if (inventoryActive == true)
        {
            inventoryActiveTimer += Time.deltaTime;

            if (inventoryActiveTimer > 0.1f)
            {
                inventoryActive = false;
                inventorySwitch.SetActive(false);
                inventoryActiveTimer = 0;
            }
        }

        if (!inventorySwitch.activeSelf && Input.GetButtonDown("Jump"))
        {
            inventorySwitch.SetActive(true);
        }
    }

    public void HasChanged()
    {
        //itemID 1 = consumable
        if (INV_DragHandeler.itemBeingDragged.GetComponent<Item>().itemID == 1)
        {
            inventoryText.color = Color.red;
        }

        //itemID 2 = useable
        if (INV_DragHandeler.itemBeingDragged.GetComponent<Item>().itemID == 2)
        {
            inventoryText.color = Color.cyan;
        }

        //itemID 3 = weapon
        if (INV_DragHandeler.itemBeingDragged.GetComponent<Item>().itemID == 3)
        {
            inventoryText.color = Color.green;
        }

        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<INV_Slot>().item;
            if (item)
            {
                //zorgt ervoor dat specificaties van de items worden weergegeven
                builder.Append(" ~ ");
                builder.Append(item.name);
                builder.Append(" : ");
                builder.Append("Weight: " + item.GetComponent<Item>().itemWeight);
                builder.Append(" ~ ");
            }
        }
        inventoryText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}

