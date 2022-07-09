using Assets.Scripts.ScriptableObjects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

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

    [Header("Play walkingSFX from SoundManager")]
    [SerializeField]
    private UnityEvent startWalkingEvents;

    //We will stop the walkingSFX when there is no Arrow
    //Or onKill Tween
    [SerializeField]
    private UnityEvent stopWalkingEvents;

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

        //Reset arrowHasSpawned value back to false
        mouseScriptableObject.ArrowHasSpawned = false;

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

    //Public method to access from MouseClickPostion and DialogueRunner StartNode
    //This method is call when player click Mouse
    public void Stop_PlayerMoveDOTween()
    {
        if (canPlayerMove == true)
        {
            //StopPlayerTween();
            OnComplete_MultipleMethods();
            PlayerMoveDOTween();
        }

        else
        {
            //We force kill a tween when dialogue is running
            //So Lilly doesn't glide while talking
            DOTween.Kill("PlayerWalk");
            //Debug.Log("Kill PlayerWalkTween");
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
        //Small math to calculation the proportion between playerPos and RaycastHitValue
        //And the proportion will be the duration amount
        //By doing so, player tween faster in smaller distance/tween slower at larger distance
        if (mouseScriptableObject.MousePositionValue.x > player.transform.position.x)
        {
            proportionValue = mouseScriptableObject.RaycastHitValue.x - player.transform.position.x;
            /*Debug.Log("Mouse " + mouseScriptableObject.MousePositionValue.x
                + " > player " + player.transform.position.x
                + " propValue: " + proportionValue);*/
        }
        else
        {
            proportionValue = player.transform.position.x - mouseScriptableObject.RaycastHitValue.x;
            /*Debug.Log("Player " + player.transform.position.x
                + " > Mouse " + mouseScriptableObject.MousePositionValue.x
                + " propValue: " + proportionValue);*/
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
        playerScriptableObject.IsRunning = true;
        var playerNewPos = new Vector2(player.transform.position.x, player.transform.position.y);
        //Play Walking SFX
        StartWalkingSFX();


        player.transform.DOMoveX(
            mouseScriptableObject.RaycastHitValue.x,
            playerScriptableObject.TweenDurationProportionValue,
            playerScriptableObject.MoveTweenSnapping)
            .SetId("PlayerWalk")
            .SetEase(playerScriptableObject.EaseType)
            .OnKill(OnKill_MultipleMethods) //If "suddenly" the Kill command is called -> Execute the OnKill_MultipleMethods
            .OnComplete(OnComplete_MultipleMethods); //If the tween is allowed to play peacefully -> Execute OnComplete
        //Quick DOTween movement -> very rigid but works


        //lastMouseClickPos = mouseScriptableObject.MousePositionValue;
        playerScriptableObject.PlayerPositionValue = playerNewPos;
        playerScriptableObject.RoundPlayerPositionValue();

        FlipingSprite();
    }

    //A collected method since .OnComplete now allow multiple method
    private void OnComplete_MultipleMethods()
    {
        //StopWalkingSFX();
        ResetHasSpawnedArrow();
        //Debug.Log("Tween complete");

        //When spamming Mouse old tween keeps going upon new tween.
        //Causing the is Running to glitch out
        playerScriptableObject.IsRunning = false;
    }

    private void OnKill_MultipleMethods()
    {
        StopWalkingSFX();
        //When the tween is purposefully killed.
        //Make the player tween to the current player's Stop position
        //Aka, stay still/doesn't move
        player.transform.DOMoveX(
            player.transform.position.x,
            0,
            playerScriptableObject.MoveTweenSnapping)
            .SetId("PlayerWalk_StayStill")
            .SetEase(playerScriptableObject.EaseType)
            .OnComplete(OnComplete_MultipleMethods);
    }
    //After Tween Animation -> Player can spawn HUD_Arrow again
    private void ResetHasSpawnedArrow()
    {
        mouseScriptableObject.ArrowHasSpawned = false;
        //Debug.Log("Reset ArrowHasSpawned");
    }

    public void StopWalkingSFX()
    {
        stopWalkingEvents?.Invoke();
    }

    public void StartWalkingSFX()
    {
        startWalkingEvents?.Invoke();
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
    //public method is to activate through DialogRunner's Event
    public void ChangePlayerMove(bool canMove)
    {
        if (!canMove)
        {
            canPlayerMove = false;
        }
        else
        {
            canPlayerMove = true;
        }
    }

    //Changing Game State through event -> PlayerMovement act as caller
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}