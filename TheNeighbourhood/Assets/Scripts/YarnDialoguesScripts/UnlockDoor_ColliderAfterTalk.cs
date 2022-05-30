using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
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

    void Start()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        AccessYarnHasTalkedNPCValue();

        Un_LockDoorStatus();
    }

    void Update()
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
            Debug.Log("There is InMemoryVariableStorage");
        }

        else
        {
            Debug.Log("There is no GO of type InMemoryVariableStorage");
        }
        
    }
}