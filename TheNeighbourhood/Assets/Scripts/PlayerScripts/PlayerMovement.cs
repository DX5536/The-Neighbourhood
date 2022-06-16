using Assets.Scripts.ScriptableObjects;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    //Make this a singleton
    /*private static PlayerMovement instance;
    public static PlayerMovement Instance
    {
        get { return instance; }
    }*/

    [Header("Mouse and Cursor's Value")]
    [SerializeField]
    private MouseScriptableObject mouseScriptableObject;

    [Header("Player's Value")]
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    //private Vector2 playerCurrentPos;

    /*[Header("Player's Char Controller")]
    [SerializeField]
    private CharacterController characterController;*/
    //[SerializeField]
    //private float playerSpeed = 2.0f;

    [Header("READ_ONLY")]
    [SerializeField]
    private float proportionValue;

    [SerializeField]
    private bool canPlayerMove = true;

    //[SerializeField]
    //private MouseClickPosition mouseScriptableObject;
    //[SerializeField]
    //private Vector2 lastMouseClickPos;

    /*[Header("DOTween's Value -> Linear means constant speed")]
    [SerializeField]
    private float tweenDuration;
    //[SerializeField]
    private bool isTweenSnapOn;
    [SerializeField]
    private Ease easeType;*/

    //[SerializeField]
    //private int speed;

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
    }

    public Vector2 PlayerCurrentPos
    {
        get
        {
            return playerCurrentPos;
        }
    }*/

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        //playerRb = player.GetComponent<Rigidbody2D>();
        //characterController = player.GetComponent<CharacterController>();

        //mouseScriptableObject = FindObjectOfType<MouseClickPosition>();
        DOTween.SetTweensCapacity(2000, 100);
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //PlayerMoveDOTween();
        //PlayerMoveCharacterController();
    }

    private void FixedUpdate()
    {
        //PlayerMoveDOTween();
        //PlayerMoveAnimator();
        //PlayerMoveDOTween();
    }

    //public to access from Unity Event of MouseClickPosition
    public void PlayerMoveDOTween()
    {
        if (canPlayerMove == true)
        {
            CalcTweenProportionValue();
            PlayerTween();
        }
    }

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

    private void CalcTweenProportionValue()
    {
        //Small math to calc the proportion between playerPos and RaycastHitValue
        //And the proportion will be the duration amount
        //By doing so, player tween faster in smaller distance/tween slower at larger distance
        if (mouseScriptableObject.MousePositionValue.x > player.transform.position.x)
        {
            proportionValue = mouseScriptableObject.RaycastHitValue.x - player.transform.position.x;
            Debug.Log("Mouse " + mouseScriptableObject.MousePositionValue.x
                + " > player " + player.transform.position.x
                + " propValue: " + proportionValue);
        }
        else
        {
            proportionValue = player.transform.position.x - mouseScriptableObject.RaycastHitValue.x;
            Debug.Log("Player " + player.transform.position.x
                + " > Mouse " + mouseScriptableObject.MousePositionValue.x
                + " propValue: " + proportionValue);
        }

        proportionValue = Mathf.Abs(proportionValue); //No negative value

        //clamp the value so it never go over MoveTweenDuration
        proportionValue = Mathf.Clamp(proportionValue, 0.5f, playerScriptableObject.MoveTweenDuration);

        //Set tweenProportionValue from playerSO
        //So Animator's playtime can read
        playerScriptableObject.TweenDurationProportionValue = proportionValue;
        playerScriptableObject.RoundTweenDurationProportionalValue();
    }

    private void PlayerTween()
    {
        var playerNewPos = new Vector2(player.transform.position.x, player.transform.position.y);

        //Quick DOTween movement -> very rigid but works
        player.transform.DOMoveX(mouseScriptableObject.RaycastHitValue.x,
            playerScriptableObject.TweenDurationProportionValue,
            playerScriptableObject.MoveTweenSnapping)
            .SetEase(playerScriptableObject.EaseType);

        //lastMouseClickPos = mouseScriptableObject.MousePositionValue;
        playerScriptableObject.PlayerPositionValue = playerNewPos;
        playerScriptableObject.RoundPlayerPositionValue();

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
    private void FlipingSprite()
    {
        //Now check: if Mouse click Right -> Mouse's x-Value bigger than playerCurrentPos
        //Mouse > Player = no flip
        if (mouseScriptableObject.MousePositionValue.x > player.transform.position.x)
        {
            playerSpriteRenderer.flipX = false;
            //Debug.Log("Player moving Right");
        }

        //Mouse click Left -> Mouse's x-Value smaller than playerCurrentPos
        //Player > Mouse = Flip
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