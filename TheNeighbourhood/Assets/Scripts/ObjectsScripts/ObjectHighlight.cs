using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class ObjectHighlight : MonoBehaviour
{
    
    [SerializeField]
    private string playerTag = "Player";

    //[SerializeField]
    private SpriteRenderer objectSpriteRenderer;

    [Header("Sprite Materials")]
    [SerializeField]
    private Material spritesDefault_MAT;

    [SerializeField]
    private Material outline_MAT;

    void Start()
    {
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player Enter");
            objectSpriteRenderer.material = outline_MAT;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player Exit");
            objectSpriteRenderer.material = spritesDefault_MAT;
        }
    }
}