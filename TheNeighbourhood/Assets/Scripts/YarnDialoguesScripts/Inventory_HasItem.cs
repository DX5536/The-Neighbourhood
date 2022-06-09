using UnityEngine;
using Yarn.Unity;

public class Inventory_HasItem: MonoBehaviour
{
    [Header("This will auto-assign by Inventory_Slot_00: READ_ONLY")]
    [SerializeField]
    private GameObject[] itemIcons;

    public GameObject[] ItemIcons
    {
        get
        {
            return itemIcons;
        }
        set
        {
            itemIcons = value;
        }
    }

    [Header("READ_ONLY")]
    [SerializeField]
    private InMemoryVariableStorage storage;

    [SerializeField]
    private string currentGainedItem;

    private void Start()
    {
        //First find the storage by tag (cuz I need the storage in non-DialogRunner too)
        storage = FindObjectOfType<InMemoryVariableStorage>();

        //storage = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InMemoryVariableStorage>();
    }

    [YarnCommand("AccessYarnGainedItemValue")]
    public void AccessYarnGainedItemValue()
    {
        storage.TryGetValue("$gainedItem_Name", out currentGainedItem);
    }

    [YarnCommand("DisplayGainedItem")]
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