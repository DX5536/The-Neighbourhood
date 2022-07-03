using UnityEngine;
using Yarn.Unity;


public class CaroNodesManager: MonoBehaviour
{
    /// <summary>
    /// The idea of this manager is to check if Player has already talk to Grandparents
    /// If they do, YarnStartNode will be a different one
    /// </summary>
    /// 
    [Header("Has talked to")]
    [SerializeField]
    private HasTalkedToNPC_ScriptableObject hasTalkedToNPC_ScriptableObject;
    [SerializeField]
    private ItemScriptableObject _NPC_Rabbit_ScriptableObject;
    [SerializeField]
    private YarnCommandsCharacterController _NPC_Rabbit;

    [Header("DialogueSystem_AUTOFind")]
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private InMemoryVariableStorage storage;

    [Header("HasTalkGrandP variables_READ_ONLY")]
    [SerializeField]
    private bool hasTalked_Grandma;
    [SerializeField]
    private bool hasTalked_Grandpa;

    void Start()
    {
        //Reset first just in case
        hasTalkedToNPC_ScriptableObject.ResetAllHasTalkedToFalse();

        //To Auto-find DialogueRunner and InMemoryVariable
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        storage = GameObject.FindGameObjectWithTag("VariableStorage").GetComponent<InMemoryVariableStorage>();

        //Get Yarn's var and save it locally to access later
        GetHasTalkedGrandParentsVar();
        //After getting the Grandparents' variables
        //Check if this is a re-visit to disable AutoStart
        ReVisit_NPCRabbit_Caro();
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
        //If Player has talked with Grandparents -> value = true:

        if (hasTalked_Grandma && hasTalked_Grandpa)
        {
            //Deactivate AutoStart
            dialogueRunner.startAutomatically = false;
            //Caro is not near the boxes but in her room -> Not visible
            //Init Spawn when go back to room
            _NPC_Rabbit.TargetSpawn(0, "NPC_Rabbit_MoveGoal", false);
            Debug.Log("No Start Automatically");
        }
        //If not = First start the game
        else
        {
            //Activate AutoStart
            dialogueRunner.startAutomatically = true;
            Debug.Log("First time play the game!");
        }
    }
}