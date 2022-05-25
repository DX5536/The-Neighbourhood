using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    //Make this a singleton
    /*private static PlayerMovement instance;
    public static PlayerMovement Instance
    {
        get { return instance; }
    }*/

    [Header("Player's Value")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector2 playerCurrentPos;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    /*[Header("Player's Char Controller")]
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float playerSpeed = 2.0f;*/


    //[SerializeField]
    private bool canPlayerMove = true;

    [Header("Mouse and Cursor's Value")]
    [SerializeField]
    private MouseClickPosition mouseManager;
    [SerializeField]
    private Vector2 lastMouseClickPos;

    [Header("DOTween's Value")]
    [SerializeField]
    private float tweenDuration;
    //[SerializeField]
    private bool isTweenSnapOn;
    [SerializeField]
    private Ease easeType;


    /*private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("There are 2 instances");
            //Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }*/

    //Property of lastMouseClickPos to access from StairManager
    public Vector2 LastMouseClickPos
    {
        get { return lastMouseClickPos; }
    }

    public Vector2 PlayerCurrentPos
    {
        get { return playerCurrentPos; }
    }

    //Subscribe to GameStateChange Event
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    //Unsubscribe from event
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        //characterController = player.GetComponent<CharacterController>();

        mouseManager = FindObjectOfType<MouseClickPosition>();
        DOTween.SetTweensCapacity(2000 , 100);
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        PlayerMoveDOTween();
        //PlayerMoveCharacterController();
    }

    private void PlayerMoveDOTween()
    {
        if (canPlayerMove == true)
        {
            //Quick DOTween movement -> very rigid but works
            player.transform.DOMoveX(mouseManager.MousePositionValue.x , tweenDuration , isTweenSnapOn).SetEase(easeType);

            lastMouseClickPos = mouseManager.MousePositionValue;
            playerCurrentPos = player.transform.position;

            FlipingSprite();

            //In Space movement!!! (Like a real Ninja)
            /*if (mouseManager.IsPlayerMoving && (Vector2)transform.position != lastClickPos)
            {
                //Check if we are in the lastClickPos. If FALSE, move to it.
                float step = playerSpeed * Time.deltaTime;
                playerRigidBody.transform.position = Vector2.MoveTowards(player.transform.position, lastClickPos, step);
            }

            else
            {
                //If reach lastClickPos -> Can't move until mouseClick again
                mouseManager.IsPlayerMoving = false;
            }*/
        }
    }

    /*private void PlayerMoveCharacterController()
    {
        if (canPlayerMove == true)
        {
            characterController.SimpleMove(mouseManager.MousePositionValue * Time.deltaTime * playerSpeed);

            lastMouseClickPos = mouseManager.MousePositionValue;
            playerCurrentPos = player.transform.position;

            FlipingSprite();
        }
    }*/

    private void FlipingSprite()
    {
        //Now check: if Mouse click Right -> Mouse's x-Value bigger than playerCurrentPos
        if (playerCurrentPos.x < lastMouseClickPos.x)
        {
            playerSpriteRenderer.flipX = false;
            //Debug.Log("Player moving Right");
        }

        //Mouse click Left -> Mouse's x-Value smaller than playerCurrentPos
        else
        {
            playerSpriteRenderer.flipX = true;
            //Debug.Log("Player moving Left");
        }
    }

    //public method for DialogueRunner -> Can't move when dialog playing
    public void ChangePlayerMoveTrue()
    {
        canPlayerMove = true;
    }

    public void ChangePlayerMoveFalse()
    {
        canPlayerMove = false;
    }

    //Changing Game State through event -> PlayerMovement act as caller
    private void OnGameStateChanged (GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}