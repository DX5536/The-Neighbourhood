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
    private string playerTag = "Player";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            dialogueRunner.StartDialogue(nodeToStart);
        }
    }
}