using System.Collections;
using UnityEngine;
using Yarn.Unity;
using static Yarn.Unity.DialogueAdvanceInput;

public class StartYarnDialogueRunner: MonoBehaviour
{
    [Header("Access my Yarn DialogueRunner -> Start Dialog")]
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private ItemScriptableObject _NPC_ScriptableObject;

    //No need for this anymore -> Yarn has DialogueAdvance Input (Script)
    [SerializeField]
    private string keyToPress_DEBUG = "e";

    [SerializeField]
    private DialogueAdvanceInput dialogueAdvanceInput;

    void Start()
    {
        //This line is too foolproof the var
        //_NPC_ScriptableObject.IsInteractable = true;


        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner != null)
        {
            //This is the send safety net if 1st search didn't work for some reason
            //Debug.Log("Have to do an 2nd in-depth search");
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        }

        dialogueAdvanceInput = FindObjectOfType<DialogueAdvanceInput>();
        if (dialogueAdvanceInput != null)
        {
            dialogueAdvanceInput = GameObject.Find("Line View").GetComponent<DialogueAdvanceInput>();
        }

        //Items have to be reset isInteract
        //Else random last isInteract Item's node will play
        _NPC_ScriptableObject.SetIsInteractable();
    }

    void Update()
    {
        //This is only for NPC
        if (_NPC_ScriptableObject.IsInteractable == true)
        {
            CheckIfDialogIsRunning();
        }
        else
        {
            //Debug.Log("Can't start dialogue");
        }
    }

    /*private void ClickEToContinue()
    {
        //Need to press Key to talk
        if (Input.GetKeyDown(keyToPress_DEBUG))
        {
            //If dialog is running -> Click E to activate LineView.OnContinueClicked()
            if (dialogueRunner.IsDialogueRunning)
            {
                continueTextEvent?.Invoke();
            }

            //If dialogue is NOT running -> Start Node
            else
            {
                //Debug.Log("Player can E to talk");

            }

        }
    }*/

    private void CheckIfDialogIsRunning()
    {
        if (Input.GetKeyDown(keyToPress_DEBUG))
        {
            if (dialogueRunner.IsDialogueRunning == true)
            {
                //Debug.Log("Dialog is running. No new node start!");
            }
            else if (dialogueRunner.IsDialogueRunning == false)
            {
                dialogueRunner.StartDialogue(_NPC_ScriptableObject.NodeName);
                StartCoroutine(WaitToClickContinue());
                Debug.Log("Object " + this.gameObject.name + " Start YarnNode: " + _NPC_ScriptableObject.NodeName);
            }
        }
        else
        {
            return;
        }
    }

    private ContinueActionType ContinueLineAfterStarting()
    {
        //ContinueActionType.KeyCode;
        return ContinueActionType.KeyCode;
    }

    //Player can click Key to talk upon reaching Talk-Zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dialogueRunner.StartDialogue(nodeToStart);
        if (collision.tag == _NPC_ScriptableObject.PlayerTag)
        {
            _NPC_ScriptableObject.IsInteractable = true;
            //Debug.Log("Player in Range of " + this.gameObject.name + _NPC_ScriptableObject.NodeName);
        }
    }

    //Player can't talk once out of reach
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _NPC_ScriptableObject.PlayerTag)
        {
            _NPC_ScriptableObject.IsInteractable = false;
            //Debug.Log("Player in Range of " + this.gameObject.name + _NPC_ScriptableObject.NodeName);
        }
    }

    private IEnumerator WaitToClickContinue()
    {
        //Wait for at least 1 so player can click ContinueText again
        dialogueAdvanceInput.enabled = false;
        yield return new WaitForSeconds(1.5f);
        dialogueAdvanceInput.enabled = true;
    }
}