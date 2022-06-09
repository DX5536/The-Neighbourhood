using UnityEngine;
using Yarn.Unity;

public class UnlockDoor_ColliderAfterTalk: MonoBehaviour
{
    [SerializeField]
    private ItemScribtableObject lockedDoorSO;

    [SerializeField]
    private SceneTransitionColliderManager sceneTransitionColliderManager;

    [SerializeField]
    private GameObject objectCanvas;

    [Header("READ_ONLY")]
    [SerializeField]
    private bool unlockedDoor_NPC_Bird = false;

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

        AccessYarnHasTalkedNPCValue();

        Un_LockDoorStatus();
    }

    private void Update()
    {
    }

    private void Un_LockDoorStatus()
    {
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

    private void AccessYarnHasTalkedNPCValue()
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
}