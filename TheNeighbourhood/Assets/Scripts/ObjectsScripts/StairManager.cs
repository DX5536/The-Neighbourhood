using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class StairManager : MonoBehaviour
{
    [Header("The chosen Stair")]
    [SerializeField]
    private GameObject chosenStair_Step;
    //[SerializeField]
    private BoxCollider2D chosenStepBoxCollider2D;
    //[SerializeField]
    private PlatformEffector2D chosenStepPlatformEffector;
    //This value is so our one-way platform can pick/lift up Player
    [SerializeField]
    private float altRotationalOffset = -15f;

    [Header("PlayerMovement and it's value")]
    [SerializeField]
    private PlayerMovement playerMovement;

    private string playerTag = "Player";

    void Start()
    {
        chosenStepBoxCollider2D = chosenStair_Step.GetComponent<BoxCollider2D>();
        chosenStepPlatformEffector = chosenStair_Step.GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            ActivateUpperStair();
        }
        
    }

    //Similar to FlipSprite by PlayerMovement, we will check the lastMouseClickPos vs the playerCurrentPos
    private void ActivateUpperStair()
    {
        //Now check: if Mouse click Above player -> Mouse's y-Value bigger than playerCurrentPos
        //Rotational Offset to -15
        if (playerMovement.PlayerCurrentPos.y < playerMovement.LastMouseClickPos.y)
        {
            chosenStepBoxCollider2D.enabled = true;
            chosenStepPlatformEffector.rotationalOffset = altRotationalOffset;
            //Debug.Log("Player moving Right");
        }

        //Mouse click Below Player -> Mouse's y-Value smaller than playerCurrentPos
        //Rotational Offset to 0
        else
        {
            chosenStepBoxCollider2D.enabled = false;
            //chosenStepPlatformEffector.rotationalOffset = 0;
            //Debug.Log("Player moving Left");
        }
    }
}