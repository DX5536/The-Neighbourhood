using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour, IDoorInteractable
{
    [Header("Door Scene")]
    [SerializeField]
    private int sceneToLoadIndex;

    public void OpenDoor()
    {
        //Debug.Log("Can switch :DDD");
        SceneManager.LoadScene(sceneToLoadIndex);
    }
}