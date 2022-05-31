using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class CameraEventManager : MonoBehaviour
{
    //Make this a singleton
    private static CameraEventManager instance;

    private void Awake()
    {
        //Create an instance
        if (instance != null)
        {
            Debug.Log("There are more than 1 " + gameObject.name);
            Destroy(this);
        }

        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static event Action<int> onVCameraTransitioned;

    public static void VCameraTransitioned(int cameraID)
    {
        if (onVCameraTransitioned != null)
        {
            onVCameraTransitioned(cameraID);
        }
    }

    public static event Action onNPC_1CameraPos;
    public static void NPC_1CameraPos()
    {
        if (onNPC_1CameraPos != null)
        {
            onNPC_1CameraPos();
        }
    }
}