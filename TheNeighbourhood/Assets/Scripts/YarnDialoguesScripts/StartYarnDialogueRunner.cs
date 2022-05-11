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

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    [SerializeField]
    private string playerTag = "Player";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Auto talk upon reaching range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dialogueRunner.StartDialogue(nodeToStart);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Need to press Key to talk
            if (Input.GetKeyDown(keyToPress_DEBUG))
            {
                dialogueRunner.StartDialogue(nodeToStart);
            }

            
            //dialogueRunner.StartDialogue(nodeToStart);
        }
    }
}