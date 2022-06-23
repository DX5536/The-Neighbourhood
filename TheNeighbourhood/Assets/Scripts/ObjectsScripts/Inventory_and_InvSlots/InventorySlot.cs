using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySlot: MonoBehaviour
{
    [SerializeField]
    private int managerSlotIndex;

    [Header("READ_ONLY")]
    [SerializeField]
    private Inventory_HasItem inventory_HasItem;

    [SerializeField]
    private GameObject childItemIcon;

    private void OnEnable()
    {
        //Auto get the icon Game object inside the slot
        //This has to be before calling the SceneChange Event
        //If in Start() => inventory_HasItem.ItemIcons[managerSlotIndex] = null
        childItemIcon = this.transform.GetChild(0).gameObject;

        SceneManager.activeSceneChanged += SearchInventoryManager;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= SearchInventoryManager;
    }

    void Start()
    {

    }


    private void SearchInventoryManager(Scene currentScene, Scene nextScene)
    {
        //Auto search for my inventory manager
        inventory_HasItem = FindObjectOfType<Inventory_HasItem>();
        //If there is something
        if (inventory_HasItem)
        {
            //Assign my childItemIcon to the Array with the index written in this script
            inventory_HasItem.ItemIcons[managerSlotIndex] = childItemIcon;
            //Debug.Log("Assign childItemIcon to ItemIcons[]");

        }

        else
        {
            //If there is no InvManager -> Error
            Debug.Log("Cannot find InventoryManager with script");
        }
    }
}