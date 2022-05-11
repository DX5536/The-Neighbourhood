using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Yarn.Unity;


public class StartYarnDialogueRunner : MonoBehaviour
{
    [Header("Access my Yarn DialogueRunner -> Start Dialogue")]
    [SerializeField]
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string nodeToStart;

    //[SerializeField]
    private bool canPlayerSpeakToNPC;

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    [SerializeField]
    private string playerTag = "Player";

    void Start()
    {
        //Start with false to avoid bugs
        canPlayerSpeakToNPC = false;
    }

    void Update()
    {
        if (canPlayerSpeakToNPC == true)
        {
            //Need to press Key to talk
            if (Input.GetKeyDown(keyToPress_DEBUG))
            {
                Debug.Log("Player can E to talk");
                dialogueRunner.StartDialogue(nodeToStart);
            }
        }
    }

    //Player can click Key to talk upon reaching Talk-Zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dialogueRunner.StartDialogue(nodeToStart);
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player in Range");

            canPlayerSpeakToNPC = true;
        }
    }

    //Player can't talk once out of reach
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player out of Range");

            canPlayerSpeakToNPC = false;

        }
    }
}