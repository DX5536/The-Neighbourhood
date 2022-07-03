using UnityEngine;
using Yarn.Unity;

public class UnlockDoor_ColliderAfterTalk: MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField]
    private ItemScriptableObject lockedDoorSO;
    [SerializeField]
    private HasTalkedToNPC_ScriptableObject hasTalkedToNPC_ScriptableObject;

    [SerializeField]
    private SceneTransitionColliderManager sceneTransitionColliderManager;

    [Header("READ_ONLY")]
    [SerializeField]
    private bool unlockedDoor_ToHallway = false;

    [SerializeField]
    private bool unlockedDoor_NPC_Grandparents = false;

    [SerializeField]
    private bool unlockedDoor_NPC_Wolf = false;

    [SerializeField]
    private bool unlockedDoor_NPC_Bird = false;

    [SerializeField]
    private bool unlockedDoor_NPC_Squirrel = false;

    [SerializeField]
    private InMemoryVariableStorage variableStorage;

    //[SerializeField]
    //private Collider2D lockedNPCDoor_Collider;

    private void Start()
    {
        //Reset isInteractable
        lockedDoorSO.SetIsInteractable();
        //Reset all the UnlockedDoorVar to False
        hasTalkedToNPC_ScriptableObject.ResetAllUnlockedDoorToFalse();

        //Find the Yarn InMemoryVarStorage
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();

        if (variableStorage != null)
        {
            //This is the send safety net if 1st search didn't work for some reason
            //Debug.Log("Have to do an 2nd in-depth search");
            variableStorage = GameObject.Find("InMemoryVariableStorage").GetComponent<InMemoryVariableStorage>();
        }

        //Check the current status of the door based on Yarn's variables
        UpdateHasUnlockedVar_With_SO();
    }

    private void Update()
    {
    }

    [YarnCommand("Un_LockDoor")]
    public void Un_LockDoor_Status(string doorName)
    {
        //Update the vars with SO upon call this Un_Lock command
        UpdateHasUnlockedVar_With_SO();

        switch (doorName)
        {
            case ("Grandparents"):
                Un_LockDoor_Grandparents_Status();
                break;
            case ("ToHallway"):
                Un_LockDoor_ToHallway_Status();
                break;
            case ("Wolf"):
                Un_LockDoor_Wolf_Status();
                break;
            case ("Bird"):
                Un_LockDoor_Bird_Status();
                break;
            case ("Squirrel"):
                Un_LockDoor_Squirrel_Status();
                break;
            case (null):
                Debug.Log("No door to unlock");
                break;
        }
    }

    //First I read all the hasDoorUnlocked Value in Memory storage
    //Then I assign them to the Scriptable Object => To be up-to-date with the latest values
    private void UpdateHasUnlockedVar_With_SO()
    {
        if (variableStorage != null)
        {
            //Try get the value
            variableStorage.TryGetValue("$unlockedDoor_ToHallway", out unlockedDoor_ToHallway);
            variableStorage.TryGetValue("$unlockedDoor_NPC_Grandparents", out unlockedDoor_NPC_Grandparents);
            variableStorage.TryGetValue("$unlockedDoor_NPC_Wolf", out unlockedDoor_NPC_Wolf);
            variableStorage.TryGetValue("$unlockedDoor_NPC_Bird", out unlockedDoor_NPC_Bird);
            variableStorage.TryGetValue("$unlockedDoor_NPC_Squirrel", out unlockedDoor_NPC_Squirrel);

            //Assign the local unlockedDoor values to HasTalked_ScriptableObjects
            hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_ToHallway = unlockedDoor_ToHallway;
            hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Grandparents = unlockedDoor_NPC_Grandparents;
            hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Wolf = unlockedDoor_NPC_Wolf;
            hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Bird = unlockedDoor_NPC_Bird;
            hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Squirrel = unlockedDoor_NPC_Squirrel;
        }
    }

    private void Un_LockDoor_Grandparents_Status()
    {
        if (hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Grandparents)
        {
            lockedDoorSO.IsInteractable = true;
            sceneTransitionColliderManager.enabled = true;
            Debug.Log("Unlock GrandP doors");
        }
        else
        {
            lockedDoorSO.IsInteractable = false;
            sceneTransitionColliderManager.enabled = false;
            Debug.Log("Lock GrandP doors");
        }
    }

    private void Un_LockDoor_ToHallway_Status()
    {
        if (hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_ToHallway)
        {
            lockedDoorSO.IsInteractable = true;
            sceneTransitionColliderManager.enabled = true;
            Debug.Log("Unlock Hallway doors");
        }
        else
        {
            lockedDoorSO.IsInteractable = false;
            sceneTransitionColliderManager.enabled = false;

            Debug.Log("Lock Hallway doors");
        }
    }

    private void Un_LockDoor_Wolf_Status()
    {
        if (hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Wolf)
        {
            sceneTransitionColliderManager.enabled = true;
            lockedDoorSO.IsInteractable = true;
        }
        else
        {
            sceneTransitionColliderManager.enabled = false;
            lockedDoorSO.IsInteractable = false;
        }
    }

    private void Un_LockDoor_Bird_Status()
    {
        if (hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Bird)
        {
            sceneTransitionColliderManager.enabled = true;
            lockedDoorSO.IsInteractable = true;
        }
        else
        {
            sceneTransitionColliderManager.enabled = false;
            lockedDoorSO.IsInteractable = false;
        }
    }

    private void Un_LockDoor_Squirrel_Status()
    {
        if (!hasTalkedToNPC_ScriptableObject.HasUnlockedDoor_NPC_Squirrel)
        {
            sceneTransitionColliderManager.enabled = true;
            lockedDoorSO.IsInteractable = true;
        }
        else
        {
            sceneTransitionColliderManager.enabled = false;
            lockedDoorSO.IsInteractable = false;
        }
    }
}