using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class MouseClickPosition: MonoBehaviour
{
    [Header("Player's Starting Position in Editor")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private MouseScriptableObject mouseScriptableObject;
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;

    [SerializeField]
    private PlayerMovement playerMovement;

    [Header("Player Animator")]
    [SerializeField]
    private bool canPlayAnimation;
    [SerializeField]
    private Animator playerAnimator;

    [Header("PlayerManager > PlayerMoveDOTween")]
    [SerializeField]
    private UnityEvent playerMoveEvent;

    [Header("PlayerManager > Stop_PlayerMoveDOTween")]
    [SerializeField]
    private UnityEvent stopPlayerMoveEvent;

    [Header("Player > Dust_PS > RunningDust")]
    [SerializeField]
    private UnityEvent playerCreateDustEvent;
    [SerializeField]
    private UnityEvent playerStopDustEvent;

    [Header("Update_AutoSearch_READ_ONLY")]
    [SerializeField]
    private GameObject myHUDArrow;

    //[SerializeField]
    //private float tweenParamValue;


    //Property to access saved mouse position_Read Only
    /*public Vector2 MousePositionValue
    {
        get { return mousePositionValue; }
    }*/

    /*public bool IsPlayerMoving
    {
        get { return isPlayerMoving; }
        set { isPlayerMoving = value; }
    }*/


    private void OnMouseDown()
    {
        //mousePosition = Input.mousePosition;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mouseScriptableObject.MousePositionValue = player.transform.position;

        //Reset canClickMouse in case it's disable due to Yarn tests
        mouseScriptableObject.SetCanClickMouse();
        //Make sure isRunnig false at start;
        playerScriptableObject.IsRunning = false;
    }

    void Update()
    {
        //First continuously search for the HUD_Arrow
        myHUDArrow = GameObject.FindGameObjectWithTag("HUD_Arrow");
        //As PlayerWalkiAnim is depends on myHUDArrow null or not!
        PlayerWalkAnim();

        //if player allowed to click AND NO HUD_Arrow present (Read_Only)
        //ArrowHasSpawned logic in PlayerMovement.cs
        if (mouseScriptableObject.CanClickMouse == true && mouseScriptableObject.ArrowHasSpawned == false)
        {
            //Save MousePosition upon L.Click
            if (Input.GetMouseButtonDown(0))
            {
                //First save the MouseClick/Raycast collide with floor values
                PlayerWalk();
                //Destroy previous HUD just in case
                Destroy(myHUDArrow);

                //Then spawn the new one.
                mouseScriptableObject.DisplayHUDImage();
            }
        }

        //If you can click mouse
        //AND an HUD arrow has already spawned
        //AND Player is currently running
        else if (mouseScriptableObject.CanClickMouse == true
            && mouseScriptableObject.ArrowHasSpawned == true
            && playerScriptableObject.IsRunning == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Stop the walk -> Temporary reset to 0
                //So we can loop back to the if above!
                stopPlayerMoveEvent?.Invoke();
                //Debug.Log("Tween Stop on purpose");
                Debug.Log("Player click to new position while HUD still present");
            }

        }

    }

    private void FixedUpdate()
    {
        //PlayerWalkAnim();
    }

    //This method will capture the mouse click position and save it to the SO
    public void PlayerWalk()
    {
        //This alone means Mouse in all the screen position -> NOT WorldPos
        //mousePositionValue = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //mousePosition = Input.mousePosition;

        //This will convert MousePos to WorldPoint of the game
        //mousePositionValue = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var clickedPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        mouseScriptableObject.MousePositionValue = clickedPosition;
        mouseScriptableObject.RoundMousePositionValue();

        RaycastHit2D hit = Physics2D.Raycast(clickedPosition, Vector2.down);

        mouseScriptableObject.RaycastHitValue = hit.point;
        mouseScriptableObject.RoundRaycastHitValue();

        //Debug Ray
        if (hit.collider != null)
        {
            Debug.DrawRay(clickedPosition, hit.point * 100, Color.green, 5, false);
            //Debug.Log(("Raycast hit ") + hit.collider.gameObject.name);
        }

        //Invoke DOTween Walking movement
        playerMoveEvent?.Invoke();

        //PlayerWalkAnim();
        //StartCoroutine(SwitchAnimation());
        //IsPlayerMoving = true;
    }

    //This method is to activate through DialogRunner's Event
    public void ChangeCanPlayAnim(bool canWalk)
    {
        if (!canWalk)
        {
            canPlayAnimation = false;
        }
        else
        {
            canPlayAnimation = true;
        }
    }

    //public method is to activate through DialogRunner's Event
    public void ChangeCanClickMouse(bool canClick)
    {
        if (!canClick)
        {
            mouseScriptableObject.CanClickMouse = false;
        }
        else
        {
            mouseScriptableObject.CanClickMouse = true;
        }
    }

    //This method is to trigger the state changes depends on Bool value
    //Mainly for the Dialogue Runner!
    private void PlayerWalkAnim()
    {
        //If player allow to play walking animation
        //Aka not currently in a Dialogue scene
        if (canPlayAnimation == true)
        {
            //StartCoroutine(SwitchAnimation());
            SwitchAnimtion_Based_IsRunning();
        }

        else
        {
            playerAnimator.SetBool("isWalking", false);
            //Debug.Log("canPlayAnim == false");
        }

    }

    /*private IEnumerator SwitchAnimation()
    {
        //playerAnimator.SetBool("isWalking", true);
        playerAnimator.CrossFade("Walk", playerScriptableObject.TweenDurationProportionValue, 0);
        //The animation will play/stop proportional to the new tweenValue
        yield return new WaitForSecondsRealtime(playerScriptableObject.TweenDurationProportionValue);

        playerAnimator.CrossFade("Idle", 0f, 0);
        Debug.Log("Couroutine PlayerWalk stop");
        //playerAnimator.SetBool("isWalking", false);
        //playerAnimator.Play("Idle");
    }*/

    private void SwitchAnimtion_Based_IsRunning()
    {
        //isWalkingParam_Animator = playerAnimator.GetBool("isWalking");

        //We just check if there is an HUD_Arrow still present
        //Player continue to play walk animation until there is no HUD_Arrow
        if (myHUDArrow != null)
        {
            playerAnimator.SetBool("isWalking", true);
            //Debug.Log("isRunning Animation");

            //Invoke CreateDust from Dust_PS
            playerCreateDustEvent?.Invoke();
        }

        //If FindGameObject can't find any more HUD_Arrow
        //Stop the animation
        else
        {
            playerAnimator.SetBool("isWalking", false);
            //Debug.Log("isRunning Stop");

            //Invoke StopDust from Dust_PS
            playerStopDustEvent?.Invoke();
        }
    }
}