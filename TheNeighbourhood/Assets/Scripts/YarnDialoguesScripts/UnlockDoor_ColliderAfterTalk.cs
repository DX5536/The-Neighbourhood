using UnityEngine;
using Yarn.Unity;

public class UnlockDoor_ColliderAfterTalk: MonoBehaviour
{
    [SerializeField]
    private ItemScriptableObject lockedDoorSO;

    [SerializeField]
    private SceneTransitionColliderManager sceneTransitionColliderManager;

    [SerializeField]
    private GameObject objectCanvas;

    [SerializeField]
    private string inSceneDoorName = "";

    [Header("READ_ONLY")]
    [SerializeField]
    private bool unlockedDoor_NPC_Bird = false;

    [SerializeField]
    private bool unlockedDoor_NPC_Squirrel = false;

    [SerializeField]
    private bool unlockedDoor_ToHallway = false;

    [SerializeField]
    private InMemoryVariableStorage variableStorage;

    //[SerializeField]
    //private Collider2D lockedNPCDoor_Collider;

    private void Start()
    {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();

        if (variableStorage != null)
        {
            //This is the send safety net if 1st search didn't work for some reason
            //Debug.Log("Have to do an 2nd in-depth search");
            variableStorage = GameObject.Find("InMemoryVariableStorage").GetComponent<InMemoryVariableStorage>();
        }

        Un_LockDoor_Status("ToHallway");
        //Temporary fix of ToHallway door not getting value at start
        unlockedDoor_ToHallway = false;
    }

    private void Update()
    {
    }

    [YarnCommand("Un_LockDoor")]
    public void Un_LockDoor_Status(string doorName)
    {
        switch (doorName)
        {
            case ("Bird"):
                Un_LockDoor_Bird_Status();
                break;
            case ("Squirrel"):
                Un_LockDoor_Squirrel_Status();
                break;
            case ("ToHallway"):
                Un_LockDoor_ToHallway_Status();
                break;
            case (null):
                Debug.Log("No door to unlock");
                break;
        }
    }

    private void Un_LockDoor_Bird_Status()
    {
        AccessYarnHasUnlockedNPC_Bird_Value();

        if (unlockedDoor_NPC_Bird != true)
        {
            sceneTransitionColliderManager.enabled = false;
            objectCanvas.SetActive(false);
        }
        else
        {
            sceneTransitionColliderManager.enabled = true;
            objectCanvas.SetActive(true);
        }
    }

    private void Un_LockDoor_Squirrel_Status()
    {
        AccessYarnHasUnlockedNPC_Squirrel_Value();
        if (unlockedDoor_NPC_Squirrel != true)
        {
            sceneTransitionColliderManager.enabled = false;
            objectCanvas.SetActive(false);
        }
        else
        {
            sceneTransitionColliderManager.enabled = true;
            objectCanvas.SetActive(true);
        }
    }

    private void Un_LockDoor_ToHallway_Status()
    {
        AccessYarnHasUnlocked_ToHallway_Value();
        if (unlockedDoor_ToHallway == false)
        {
            sceneTransitionColliderManager.enabled = false;
            objectCanvas.SetActive(false);
        }
        else
        {
            sceneTransitionColliderManager.enabled = true;
            objectCanvas.SetActive(true);
        }
    }

    private void AccessYarnHasUnlockedNPC_Bird_Value()
    {
        if (variableStorage != null)
        {
            variableStorage.TryGetValue("$unlockedDoor_NPC_Bird", out unlockedDoor_NPC_Bird);
            //Debug.Log("There is InMemoryVariableStorage");

            //Assign the SO's status to be interactable
            //To change to the "outline_MAT" and pop-up active
            lockedDoorSO.IsInteractable = unlockedDoor_NPC_Bird;
        }
        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }
    }

    private void AccessYarnHasUnlockedNPC_Squirrel_Value()
    {
        if (variableStorage != null)
        {
            variableStorage.TryGetValue("$unlockedDoor_NPC_Squirrel", out unlockedDoor_NPC_Squirrel);
            //Debug.Log("There is InMemoryVariableStorage");

            //Assign the SO's status to be interactable
            //To change to the "outline_MAT" and pop-up active
            lockedDoorSO.IsInteractable = unlockedDoor_NPC_Squirrel;
        }
        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }
    }

    private void AccessYarnHasUnlocked_ToHallway_Value()
    {
        if (variableStorage != null)
        {
            variableStorage.TryGetValue("$unlockedDoor_ToHallway", out unlockedDoor_ToHallway);
            //Debug.Log("There is InMemoryVariableStorage");

            //Assign the SO's status to be interactable
            //To change to the "outline_MAT" and pop-up active

            lockedDoorSO.IsInteractable = unlockedDoor_ToHallway;
        }
        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }
    }
}