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

    private string keyToPress_DEBUG = "e";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Method1()
    {
        
    }

    public void OpenDoor()
    {
        Debug.Log("Can switch :DDD");
        SceneManager.LoadScene(sceneToLoadIndex);

        /*if (Input.GetKeyDown(keyToPress_DEBUG))
        {
            Debug.Log("Switch Scene");
            SceneManager.LoadScene(sceneToLoadIndex);
        }*/
        
    }
}