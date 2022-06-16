using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class MouseClickPosition: MonoBehaviour
{
    [Header("Player's Starting Position in Editor")]
    [SerializeField]
    private GameObject player;
    private Rigidbody2D playerRb;

    [SerializeField]
    //private Vector2 mousePositionValue;
    private MouseScriptableObject mouseScriptableObject;
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    //[SerializeField]
    //private bool isPlayerMoving;

    [Header("Player Animator")]
    [SerializeField]
    private bool canPlayAnimation;
    [SerializeField]
    private Animator playerAnimator;

    [Header("PlayerManager > PlayerMoveDOTween")]
    [SerializeField]
    private UnityEvent playerMoveEvent;

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
        playerRb = player.GetComponent<Rigidbody2D>();
        mouseScriptableObject.MousePositionValue = player.transform.position;
    }

    void Update()
    {
        //if player allowed to click
        if (mouseScriptableObject.CanClickMouse == true)
        {
            //Save MousePosition upon L.Click
            if (Input.GetMouseButtonDown(0))
            {
                PlayerWalk();
                mouseScriptableObject.DisplayHUDImage();
            }
        }

    }

    private void PlayerWalk()
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

        PlayerWalkAnim();

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
    private void PlayerWalkAnim()
    {
        if (canPlayAnimation == true)
        {
            StartCoroutine(SwitchAnimation());
        }

        else
        {
            playerAnimator.SetBool("isWalking", false);
            //playerAnimator.Play("Idle");

        }

    }

    private IEnumerator SwitchAnimation()
    {
        playerAnimator.SetBool("isWalking", true);
        //The animation will play/stop proportional to the new tweenValue
        yield return new WaitForSecondsRealtime(playerScriptableObject.TweenDurationProportionValue);

        playerAnimator.SetBool("isWalking", false);
        //playerAnimator.Play("Idle");
    }
}