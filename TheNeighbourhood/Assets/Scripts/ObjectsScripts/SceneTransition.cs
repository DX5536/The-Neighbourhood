using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    [Header("")]
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private int sceneToLoadIndex;

    //[SerializeField]
    private bool canSwitchScene = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canSwitchScene == true)
        {
            SceneManager.LoadScene (sceneToLoadIndex);
            Debug.Log("Switch Scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            Debug.Log("Player can go out!");
            canSwitchScene = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            Debug.Log("Player can go out!");
            canSwitchScene = false;
        }
    }
}