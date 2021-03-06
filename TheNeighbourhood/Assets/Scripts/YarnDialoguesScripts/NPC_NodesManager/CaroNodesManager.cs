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

    [Header("HasTalk variables_READ_ONLY")]
    [SerializeField]
    private bool hasHamantash;

    [SerializeField]
    private bool hasTalked_Grandma;
    [SerializeField]
    private bool hasTalked_Grandpa;

    [SerializeField]
    private bool hasTalked_Wolf;
    [SerializeField]
    private bool hasTalked_Bird;
    [SerializeField]
    private bool hasTalked_Squirrel;


    void Start()
    {
        //Reset first just in case
        hasTalkedToNPC_ScriptableObject.ResetAllHasTalkedToFalse();

        //To Auto-find DialogueRunner and InMemoryVariable
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        storage = GameObject.FindGameObjectWithTag("VariableStorage").GetComponent<InMemoryVariableStorage>();

        //Get Yarn's var and save it locally to access later
        GetHasTalkedVariables();
        //After getting the Grandparents' variables
        //Check if this is a re-visit to disable AutoStart
        ReVisit_NPCRabbit_Caro();
    }

    void Update()
    {

    }

    private void GetHasTalkedVariables()
    {
        //Hamantash's logic
        storage.TryGetValue("$hasHamantash", out hasHamantash);
        hasTalkedToNPC_ScriptableObject.HasHamantash = hasHamantash;

        //Grandma's logic
        storage.TryGetValue("$hasTalked_Grandma", out hasTalked_Grandma);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Grandma = hasTalked_Grandma;

        //Grandpa's logic
        storage.TryGetValue("$hasTalked_Grandma", out hasTalked_Grandpa);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Grandpa = hasTalked_Grandpa;

        //Wolf's Logic
        storage.TryGetValue("$hasTalked_NPC_Wolf", out hasTalked_Wolf);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Wolf = hasTalked_Wolf;

        //Bird's Logic
        storage.TryGetValue("$hasTalked_NPC_Bird", out hasTalked_Bird);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Bird = hasTalked_Bird;

        //Squirrel's Logic
        storage.TryGetValue("$hasTalked_NPC_Squirrel", out hasTalked_Squirrel);
        hasTalkedToNPC_ScriptableObject.HasTalkedTo_NPC_Squirrel = hasTalked_Squirrel;
    }

    private void ReVisit_NPCRabbit_Caro()
    {
        //If player has talked to all three NPC and got all ingredients
        if (hasTalked_Wolf && hasTalked_Squirrel && hasTalked_Bird)
        {
            //Caro hangs out near the boxes
            //Activate AutoStart
            dialogueRunner.startAutomatically = true;
            dialogueRunner.StartDialogue("Caro_After_Ingredients");
        }

        //If Player haven't talk to Grandparents but has Hamantash already
        //In case Player get to Hallway but comeback! -> No First start the game
        else if (!hasTalked_Grandma && !hasTalked_Grandpa && hasHamantash)
        {
            //Deactivate AutoStart
            dialogueRunner.startAutomatically = false;
            //Caro hangs out near the boxes
            Debug.Log("No Start Automatically + NOT talked to Grandparents");
        }

        //If Player has talked with Grandparents -> value = true:
        else if (hasTalked_Grandma && hasTalked_Grandpa)
        {
            //Deactivate AutoStart
            dialogueRunner.startAutomatically = false;
            //Caro is not near the boxes but in her room -> Not visible
            //Init Spawn when go back to room
            _NPC_Rabbit.TargetSpawn(0, "NPC_Rabbit_MoveGoal", false);
            Debug.Log("No Start Automatically + talked to Grandparents");
        }

        //If not = First start the game
        else
        {
            //Activate AutoStart
            dialogueRunner.startAutomatically = true;
            dialogueRunner.StartDialogue("Start_Intro");
            Debug.Log("First time play the game!");
        }
    }
}