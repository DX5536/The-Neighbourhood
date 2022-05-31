using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Yarn.Unity;
using Yarn;

public class Inventory_HasItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemIcons;

    [Header("READ_ONLY")]
    [SerializeField]
    private InMemoryVariableStorage storage;

    [SerializeField]
    private string currentGainedItem;

    void Start()
    {
        //First find the storage by tag (cuz I need the storage in non-DialogRunner too)
        storage = FindObjectOfType<InMemoryVariableStorage>();

    }

    void Update()
    {

    }

    [YarnCommand("AccessYarnGainedItemValue")]
    public void AccessYarnGainedItemValue()
    {
        storage.TryGetValue("$gainedItem_Name" , out currentGainedItem);
        /*if (storage != null)
        {
            storage.TryGetValue("$gainedItem_Name" , out currentGainedItem);
            Debug.Log("There is InMemoryVariableStorage");
        }

        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }*/

    }


    [YarnCommand("DisplayGainedItem")]
    //Public method so Yarn can access the method
    public void DisplayGainedItem()
    {
        //Debug.Log("Player gained Flour!");
        switch (currentGainedItem)
        {
            case "Flour":
                Debug.Log("Player gained Flour! in Switch-Case");
                itemIcons[0].SetActive(true);
                break;
        }
    }
}