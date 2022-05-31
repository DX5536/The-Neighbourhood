using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class CameraTransitionHandler : MonoBehaviour
{
    private string playerTag = "Player";

    [SerializeField]
    private int cameraID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            CameraEventManager.VCameraTransitioned(cameraID);
        }
    }
}