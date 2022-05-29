using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class ObjectDescriptionHandler : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private string popUpItemID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player Enter call Event");
            ObjectDescriptionManager.PopupObjectDescription(popUpItemID);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player Enter");
            ObjectDescriptionManager.PopdownObjectDescription(popUpItemID);
        }
    }
}