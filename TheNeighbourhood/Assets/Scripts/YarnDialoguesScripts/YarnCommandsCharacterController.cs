using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DG.Tweening;

public class YarnCommandsCharacterController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterGO;

    [SerializeField]
    private BoxCollider2D doorBoxCollider;

    [SerializeField]
    private GameObject moveGoalGO;

    [Header("DOTween's Value -> Linear means constant speed")]
    [SerializeField]
    private float tweenDuration;
    //[SerializeField]
    private bool isTweenSnapOn;
    [SerializeField]
    private Ease easeType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("TargetMove")]
    private void TargetMove(bool isCharacterRemove)
    {
        characterGO.transform.DOMoveX(moveGoalGO.transform.position.x,tweenDuration,isTweenSnapOn);
        //If we want the character to disapear afterwards
        if (isCharacterRemove)
        {
            SetGOActive();
        }
    }

    [YarnCommand("FlipSprite")]
    private void FlipingSprite()
    {
        if (gameObject.transform.GetComponent<SpriteRenderer>().flipX == false)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;

        }
    }

    private void SetGOActive()
    {
        if (characterGO.activeSelf == false)
        {
            return;
        }

        else
        {
            characterGO.SetActive(false);
        }
    }

    [YarnCommand("En_DisableComponet")]
    private void En_DisableComponent()
    {
        if (doorBoxCollider.enabled == true)
        {
            doorBoxCollider.enabled = false;
        }

        else
        {
            doorBoxCollider.enabled = true;
        }
    }
}
