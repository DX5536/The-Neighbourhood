using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class Inventory_HasItem: MonoBehaviour
{
    [Header("Play itemSFX from SoundManager")]
    [SerializeField]
    private UnityEvent itemBehaviourEvents;

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
                StartItemSFX();
                itemIcons[0].SetActive(true);
                break;

            case "Pizza":
                Debug.Log("Player gained Pizza! in Switch-Case");
                StartItemSFX();
                itemIcons[3].SetActive(true);
                break;
            case "FrozenPizza": //Slot 3.5
                Debug.Log("Player gained Pizza! in Switch-Case");
                StartItemSFX();
                itemIcons[4].SetActive(true);
                break;
        }
    }

    [YarnCommand("UseGainedItem")]
    public void UseGainedItem()
    {
        //Debug.Log("Player gained Flour!");
        switch (currentGainedItem)
        {
            case "Flour":
                Debug.Log("Player gained Flour! in Switch-Case");
                StartItemSFX();
                itemIcons[0].SetActive(false);
                break;

            case "Pizza":
                Debug.Log("Player gained Pizza! in Switch-Case");
                StartItemSFX();
                itemIcons[3].SetActive(false);
                break;
        }
    }

    private void StartItemSFX()
    {
        itemBehaviourEvents?.Invoke();
    }
}