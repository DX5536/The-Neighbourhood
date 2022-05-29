using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class SceneTransitionColliderManager : MonoBehaviour
{
    //[Header("")]
    [SerializeField]
    private string playerTag = "Player";

    //[SerializeField]
    //private int sceneToLoadIndex;

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    //[SerializeField]
    private bool canSwitchScene = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress_DEBUG) && canSwitchScene == true)
        {
            //Debug.Log("Switch Scene");
            ToOpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player can go out!");
            canSwitchScene = true;
        }
        
    }

    void ToOpenDoor()
    {
        var doorInteractable = this.gameObject.GetComponent<IDoorInteractable>();
        if (doorInteractable == null)
        {
            Debug.Log("There is no IDoorInterface");
            return;
        }

        else
        {
            doorInteractable.OpenDoor();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player can go out!");
            canSwitchScene = false;
        }
    }

}