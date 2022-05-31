using UnityEngine;
using Yarn.Unity;

public class Inventory_HasItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemIcons;

    [Header("READ_ONLY")]
    [SerializeField]
    private InMemoryVariableStorage storage;

    [SerializeField]
    private string currentGainedItem;

    private void Start()
    {
        //First find the storage by tag (cuz I need the storage in non-DialogRunner too)
        storage = FindObjectOfType<InMemoryVariableStorage>();
    }

    private void Update()
    {
    }

    [YarnCommand("AccessYarnGainedItemValue")]
    public void AccessYarnGainedItemValue()
    {
        storage.TryGetValue("$gainedItem_Name" , out currentGainedItem);
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