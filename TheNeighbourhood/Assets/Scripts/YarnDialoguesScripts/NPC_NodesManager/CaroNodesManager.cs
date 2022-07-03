using UnityEngine;
using Yarn.Unity;


public class CaroNodesManager: MonoBehaviour
{
    /// <summary>
    /// The idea of this manager is to check if Player has already talk to Grandparents
    /// If they do, YarnStartNode will be a different one
    /// </summary>
    /// 
    [Header("Has talked to ")]
    [SerializeField]
    private HasTalkedToNPC_ScriptableObject hasTalkedToNPC_ScriptableObject;

    [Header("DialogueSystem")]
    //[SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private InMemoryVariableStorage storage;

    [SerializeField]
    private string nodeNameToPlay;

    [Header("HasTalkGrandP variables_READ_ONLY")]
    [SerializeField]
    private bool hasTalked_Grandma;
    [SerializeField]
    private bool hasTalked_Grandpa;

    void Start()
    {
        //Reset first just in case
        hasTalkedToNPC_ScriptableObject.ResetAllVarToFalse();

        //To Auto-find DialogueRunner and InMemoryVariable
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        storage = FindObjectOfType<InMemoryVariableStorage>();


    }

    void Update()
    {

    }

    private void GetHasTalkedGrandParentsVar()
    {
        //Grandma's logic
        storage.TryGetValue("$hasTalked_Grandma", out hasTalked_Grandma);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Grandma = hasTalked_Grandma;
        //Grandpa's logic
        storage.TryGetValue("$hasTalked_Grandma", out hasTalked_Grandpa);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Grandpa = hasTalked_Grandpa;
    }

    private void ReVisit_NPCRabbit_Caro()
    {

    }
}