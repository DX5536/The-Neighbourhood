using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;


public class StairManager: MonoBehaviour
{
    [Header("The chosen Stair")]
    [SerializeField]
    private GameObject[] chosenStair_Step;

    [Header("ONLY ENTER AMOUNT LIKE^")]
    [SerializeField]
    private BoxCollider2D[] chosenStepBoxCollider2D;
    [SerializeField]
    private PlatformEffector2D[] chosenStepPlatformEffector;
    //This value is so our one-way platform can pick/lift up Player
    [SerializeField]
    private float altRotationalOffset = -15f;

    //[Header("PlayerMovement and it's value")]
    //[SerializeField]
    //private PlayerMovement playerMovement;
    [SerializeField]
    private MouseScriptableObject mouseScriptableObject;
    [SerializeField]
    private bool isPlayerInFloorIntersect;

    private string playerTag = "Player";

    void Start()
    {
        //chosenStepBoxCollider2D = chosenStair_Step.GetComponent<BoxCollider2D>();
        //chosenStepPlatformEffector = chosenStair_Step.GetComponent<PlatformEffector2D>();

        for (int i = 0;i < chosenStepBoxCollider2D.Length;i++)
        {
            chosenStepBoxCollider2D[i] = chosenStair_Step[i].GetComponent<BoxCollider2D>();
            chosenStepPlatformEffector[i] = chosenStair_Step[i].GetComponent<PlatformEffector2D>();

            StartCoroutine(SmallDelay());
            chosenStepBoxCollider2D[i].enabled = false;
        }

    }

    void Update()
    {
        if (isPlayerInFloorIntersect)
        {
            ActivateUpperStair();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isPlayerInFloorIntersect = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isPlayerInFloorIntersect = false;
        }
    }

    //Similar to FlipSprite by PlayerMovement, we will check the lastMouseClickPos vs the playerCurrentPos
    private void ActivateUpperStair()
    {
        //Now check: if Mouse click Above player -> Mouse's y-Value bigger than playerCurrentPos
        /*if (playerMovement.PlayerCurrentPos.y < playerMovement.LastMouseClickPos.y)
        {
        }*/

        //Debug.Log("Player collides with StairManager");
        //NEW: Instead of checking PlayerCurrentPos vs MouseClick -> Check for Mouse's y-Value ABOVE or BELOW this Manager!!!
        var stairManagerPos = this.transform.position;
        if (stairManagerPos.y < mouseScriptableObject.RaycastHitValue.y)
        {
            for (int i = 0;i < chosenStepBoxCollider2D.Length;i++)
            {
                StartCoroutine(SmallDelay());
                chosenStepBoxCollider2D[i].enabled = true;

                //Rotational Offset to -15 on the first step
                chosenStepPlatformEffector[0].rotationalOffset = altRotationalOffset;
            }

            //chosenStepBoxCollider2D.enabled = true;
            //chosenStepPlatformEffector.rotationalOffset = altRotationalOffset;

            //Debug.Log("Player moving Right");
        }

        //Mouse click Below Player -> Mouse's y-Value smaller than playerCurrentPos
        //Rotational Offset to 0
        else
        {
            for (int i = 0;i < chosenStepBoxCollider2D.Length;i++)
            {
                chosenStepBoxCollider2D[i].enabled = false;
                //chosenStepPlatformEffector[1].rotationalOffset = altRotationalOffset;
            }

            //chosenStepBoxCollider2D.enabled = false;
            //chosenStepPlatformEffector.rotationalOffset = 0;
            //Debug.Log("Player moving Left");
        }
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Finish Delay");

    }
}