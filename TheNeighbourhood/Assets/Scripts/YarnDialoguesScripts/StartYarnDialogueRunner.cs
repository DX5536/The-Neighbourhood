using UnityEngine;
using Yarn.Unity;


public class StartYarnDialogueRunner: MonoBehaviour
{
    [Header("Access my Yarn DialogueRunner -> Start Dialog")]
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private ItemScribtableObject _NPC_ScriptableObject;

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    void Start()
    {
        //This line is too foolproof the var
        //_NPC_ScriptableObject.IsInteractable = true;

        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner != null)
        {
            //This is the send safety net if 1st search didn't work for some reason
            //Debug.Log("Have to do an 2nd in-depth search");
            dialogueRunner = GameObject.Find("Dialogue System").GetComponent<DialogueRunner>();
        }
    }

    void Update()
    {
        if (_NPC_ScriptableObject.IsInteractable == true)
        {
            //Need to press Key to talk
            if (Input.GetKeyDown(keyToPress_DEBUG))
            {
                //Debug.Log("Player can E to talk");
                dialogueRunner.StartDialogue(_NPC_ScriptableObject.NodeName);
            }
        }
    }

    //Player can click Key to talk upon reaching Talk-Zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dialogueRunner.StartDialogue(nodeToStart);
        if (collision.tag == _NPC_ScriptableObject.PlayerTag)
        {
            //Debug.Log("Player in Range");

            _NPC_ScriptableObject.IsInteractable = true;
        }
    }

    //Player can't talk once out of reach
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _NPC_ScriptableObject.PlayerTag)
        {
            //Debug.Log("Player out of Range");

            _NPC_ScriptableObject.IsInteractable = false;

        }
    }
}