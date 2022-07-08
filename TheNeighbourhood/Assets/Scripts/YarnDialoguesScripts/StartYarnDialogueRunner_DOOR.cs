using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class StartYarnDialogueRunner_DOOR: MonoBehaviour
{
    [Header("door_SO")]
    [SerializeField]
    private ItemScriptableObject doorScriptableObject;

    [Header("Access my Yarn DialogueRunner -> Start Dialog")]
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    [SerializeField]
    private DialogueAdvanceInput dialogueAdvanceInput;

    void Start()
    {
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
    }

    void Update()
    {

    }

    //Unlike normal StartYarnDialogueRunner
    //We can only start the node IF player is in the collider's zone!
    private void OnTriggerStay(Collider other)
    {
        //the isInteractable will be handled in the YarnScript
        //And Un_LockDoorAfterTalk
        if (doorScriptableObject.IsInteractable)
        {
            if (Input.GetKeyDown(keyToPress_DEBUG))
            {
                if (dialogueRunner.IsDialogueRunning == true)
                {
                    //Debug.Log("Dialog is running. No new node start!");
                }
                else if (dialogueRunner.IsDialogueRunning == false)
                {
                    dialogueRunner.StartDialogue(doorScriptableObject.NodeName);
                    StartCoroutine(WaitToClickContinue());
                    Debug.Log("Object " + this.gameObject.name + " Start YarnNode: " + doorScriptableObject.NodeName);
                }
            }

            else
            {
                return;
            }
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