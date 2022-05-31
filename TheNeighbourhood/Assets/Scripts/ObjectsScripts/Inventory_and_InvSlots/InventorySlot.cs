using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private int managerSlotIndex;

    [Header("READ_ONLY")]
    [SerializeField]
    private Inventory_HasItem inventory_HasItem;

    [SerializeField]
    private GameObject childItemIcon;

    void Start()
    {
        //Auto get the icon Game object inside the slot
        childItemIcon = this.transform.GetChild(0).gameObject;

        SearchInventoryManager();

    }

    private void SearchInventoryManager()
    {
        //Auto search for my inventory manager
        inventory_HasItem = FindObjectOfType<Inventory_HasItem>();
        //If there is something
        if (inventory_HasItem != null)
        {
            //Assign my childItemIcon to the Array with the index written in this script
            inventory_HasItem.ItemIcons[managerSlotIndex] = childItemIcon;
        }

        else
        {
            //If there is no InvManager -> Error
            Debug.Log("Cannot find InventoryManager with script");
        }
    }
}