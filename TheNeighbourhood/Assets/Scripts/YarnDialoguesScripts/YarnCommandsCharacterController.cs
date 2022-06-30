using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandsCharacterController: MonoBehaviour
{
    [SerializeField]
    private GameObject characterGO;

    //[SerializeField]
    private BoxCollider2D doorBoxCollider;

    //[SerializeField]
    //private GameObject moveGoalGO;
    [Header("The x-Offset from moveGoal.")]
    [SerializeField]
    private float moveGoal_Offset;

    //[SerializeField]
    private Vector2 character_OG_Pos;

    [Header("DOTween's Value -> Linear means constant speed")]
    [SerializeField]
    private float tweenDuration;
    //[SerializeField]
    private bool isTweenSnapOn;
    [SerializeField]
    private Ease easeType;

    void Start()
    {
        character_OG_Pos = characterGO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("TargetMove")]
    public void TargetMove_ToGoal(string goalName, bool isCharacterRemove)
    {
        var goalGameObject = GameObject.Find(goalName);

        if (goalGameObject)
        {
            var updatedMoveGoal_XValue = goalGameObject.transform.position.x + moveGoal_Offset;
            characterGO.transform.DOMoveX(updatedMoveGoal_XValue, tweenDuration, isTweenSnapOn);
            //If we want the character to disappear afterwards
            if (isCharacterRemove)
            {
                SetGOActive(true);
            }
        }

        else
        {
            Debug.Log("Call TargetMove Command but no Goal");
        }
    }

    [YarnCommand("TargetMove_Back")]
    public void TargetMove_BackToOG(bool isCharacterRemove)
    {
        characterGO.transform.DOMoveX(character_OG_Pos.x, tweenDuration, isTweenSnapOn);
        //If we want the character to disappear afterwards
        if (isCharacterRemove)
        {
            SetGOActive(true);
        }
    }

    [YarnCommand("FlipSprite")]
    private void FlipingSprite()
    {
        if (gameObject.transform.GetComponent<SpriteRenderer>().flipX == false)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;

        }
    }

    [YarnCommand("Toggle_CharacterActive")]
    private void SetGOActive(bool toSetActive)
    {
        //Turn on Character
        if (characterGO.activeSelf == false && toSetActive == true)
        {
            characterGO.SetActive(true);
        }

        //Turn off Character
        else if (characterGO.activeSelf == true && toSetActive == false)
        {
            characterGO.SetActive(false);
        }
    }

    //[YarnCommand("En_DisableComponet")]
    private void En_DisableComponent()
    {
        if (doorBoxCollider.enabled == true)
        {
            doorBoxCollider.enabled = false;
        }

        else
        {
            doorBoxCollider.enabled = true;
        }
    }
}
