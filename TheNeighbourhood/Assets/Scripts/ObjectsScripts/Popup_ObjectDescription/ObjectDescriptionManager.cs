using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;


public class ObjectDescriptionManager : MonoBehaviour
{
    //Make this a singleton
    private static ObjectDescriptionManager instance;

    private void Awake()
    {
        //Create an instance
        if (instance != null)
        {
            Debug.Log("There are more than 1 OptionValue ");
            Destroy(this);
        }

        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static event Action<string> onPopupObjectDescription;
    public static void PopupObjectDescription (string popUpDescriptionID)
    {
        if (onPopupObjectDescription != null)
        {
            onPopupObjectDescription(popUpDescriptionID);
        }
    }

    public static event Action<string> onPopdownObjectDescription;
    public static void PopdownObjectDescription(string popUpDescriptionID)
    {
        if (onPopdownObjectDescription != null)
        {
            onPopdownObjectDescription(popUpDescriptionID);
        }
    }

    
}