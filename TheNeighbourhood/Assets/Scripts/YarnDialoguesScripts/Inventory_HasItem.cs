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
        //First find the storage by type (cuz I need the storage in non-DialogRunner too)
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

            case "Eggs":
                Debug.Log("Player gain Eggs! in Switch-Case");
                StartItemSFX();
                itemIcons[1].SetActive(true);
                break;

            case "Oil":
                Debug.Log("Player gain Oil! in Switch-Case");
                StartItemSFX();
                itemIcons[2].SetActive(true);
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
                Debug.Log("Player use Flour! in Switch-Case");
                StartItemSFX();
                itemIcons[0].SetActive(false);
                break;

            case "Eggs":
                Debug.Log("Player use Eggs! in Switch-Case");
                StartItemSFX();
                itemIcons[1].SetActive(false);
                break;

            case "Oil":
                Debug.Log("Player use Oil! in Switch-Case");
                StartItemSFX();
                itemIcons[2].SetActive(false);
                break;

            case "Pizza":
                Debug.Log("Player use Pizza! in Switch-Case");
                StartItemSFX();
                itemIcons[3].SetActive(false);
                break;

            case "FrozenPizza": //Slot 3.5
                Debug.Log("Player use FrozenPizza! in Switch-Case");
                StartItemSFX();
                itemIcons[4].SetActive(false);
                break;
        }
    }

    private void StartItemSFX()
    {
        itemBehaviourEvents?.Invoke();
    }
}