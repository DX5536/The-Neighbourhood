using UnityEngine;
using Yarn.Unity;

public class UnlockDoor_ColliderAfterTalk : MonoBehaviour
{
    [Header("READ_ONLY")]
    [SerializeField]
    private bool hasPlayerTalkToNPC_0 = false;

    [SerializeField]
    private InMemoryVariableStorage variableStorage;

    [SerializeField]
    private Collider2D lockedNPCDoor_Collider;

    private void Start()
    {
        variableStorage = FindObjectOfType<InMemoryVariableStorage>();

        if (variableStorage != null)
        {
            //This is the send safety net if 1st search didn't work for some reason
            Debug.Log("Have to do an 2nd in-depth search");
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
        if (hasPlayerTalkToNPC_0 != true)
        {
            lockedNPCDoor_Collider.enabled = false;
        }
        else
        {
            lockedNPCDoor_Collider.enabled = true;
        }
    }

    private void AccessYarnHasTalkedNPCValue()
    {
        if (variableStorage != null)
        {
            variableStorage.TryGetValue("$hasTalkedToNPC0" , out hasPlayerTalkToNPC_0);
            //Debug.Log("There is InMemoryVariableStorage");
        }
        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }
    }
}