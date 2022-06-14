using System.Collections;
using DG.Tweening;
using UnityEngine;
using Assets.Scripts.ScriptableObjects;

public class PlayerMovement: MonoBehaviour
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
    private CharacterController characterController;*/
    //[SerializeField]
    //private float playerSpeed = 2.0f;


    //[SerializeField]
    private bool canPlayerMove = true;

    [Header("Mouse and Cursor's Value")]
    [SerializeField]
    private MouseScriptableObject mouseScriptableObject;
    //[SerializeField]
    //private MouseClickPosition mouseScriptableObject;
    //[SerializeField]
    //private Vector2 lastMouseClickPos;

    [Header("DOTween's Value -> Linear means constant speed")]
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
    /*public Vector2 LastMouseClickPos
    {
        get
        {
            return lastMouseClickPos;
        }
    }*/

    public Vector2 PlayerCurrentPos
    {
        get
        {
            return playerCurrentPos;
        }
    }

    //Subscribe to GameStateChange Event
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    //Unsubscripted from event
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        //characterController = player.GetComponent<CharacterController>();

        //mouseScriptableObject = FindObjectOfType<MouseClickPosition>();
        DOTween.SetTweensCapacity(2000, 100);
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        PlayerMoveDOTween();
        //PlayerMoveCharacterController();

    }

    private void FixedUpdate()
    {
        //PlayerMoveDOTween();
        //PlayerMoveAnimator();
    }

    private void PlayerMoveDOTween()
    {
        if (canPlayerMove == true)
        {
            var playerTransformPos = player.transform.position;

            //Quick DOTween movement -> very rigid but works
            player.transform.DOMoveX(mouseScriptableObject.MousePositionValue.x,
                tweenDuration,
                isTweenSnapOn)
                .SetEase(easeType);
                //.OnComplete(()=>mouseScriptableObject.ChangeCanPlayAnim(true));

            //lastMouseClickPos = mouseScriptableObject.MousePositionValue;
            playerCurrentPos = player.transform.position;

            FlipingSprite();

            //In Space movement!!! (Like a real Ninja)
            /*if (mouseScriptableObject.IsPlayerMoving && (Vector2)transform.position != lastClickPos)
            {
                //Check if we are in the lastClickPos. If FALSE, move to it.
                float step = playerSpeed * Time.deltaTime;
                playerRigidBody.transform.position = Vector2.MoveTowards(player.transform.position, lastClickPos, step);
            }

            else
            {
                //If reach lastClickPos -> Can't move until mouseClick again
                mouseScriptableObject.IsPlayerMoving = false;
            }*/
        }
    }

    /*private void PlayerMoveCharacterController()
    {
        if (canPlayerMove == true)
        {
            characterController.SimpleMove(mouseScriptableObject.MousePositionValue * Time.deltaTime * playerSpeed);

            lastMouseClickPos = mouseScriptableObject.MousePositionValue;
            playerCurrentPos = player.transform.position;

            FlipingSprite();
        }
    }*/

    //2nd Attempt on Move Player in constant speed
    /*private void PlayerMoveAnimator()
    {
        if (canPlayerMove == true)
        {
            var playerMovementTarget = new Vector2(lastMouseClickPos.x, 0f);

            player.transform.position = Vector2.MoveTowards(player.transform.position, playerMovementTarget, playerSpeed * Time.deltaTime);


            lastMouseClickPos = mouseScriptableObject.MousePositionValue;
            playerCurrentPos = new Vector2(player.transform.position.x, 0f);

            FlipingSprite();
        }
    }*/
    private void FlipingSprite()
    {
        //Now check: if Mouse click Right -> Mouse's x-Value bigger than playerCurrentPos
        if (playerCurrentPos.x < mouseScriptableObject.MousePositionValue.x)
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
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

    
}