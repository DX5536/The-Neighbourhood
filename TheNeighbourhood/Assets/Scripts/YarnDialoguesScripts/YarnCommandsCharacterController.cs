using DG.Tweening;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandsCharacterController: MonoBehaviour
{
    [SerializeField]
    private GameObject characterGO;

    //[SerializeField]
    private BoxCollider2D doorBoxCollider;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    //[SerializeField]
    //private GameObject moveGoalGO;

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
        spriteRenderer = characterGO.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Spawn target at specific position
    /// </summary>
    /// <param name="spawnOffset">Off-set from specific position</param>
    /// <param name="spawnPointName">Name of specific position (GameObject)</param>
    /// <param name="showCharacter">Make target visible?</param>
    [YarnCommand("TargetSpawn")]
    public void TargetSpawn(float spawnOffset, string spawnPointName, bool showCharacter)
    {
        var spawnPointGO = GameObject.Find(spawnPointName);

        if (spawnPointGO)
        {
            characterGO.transform.position = new Vector3(spawnPointGO.transform.position.x + spawnOffset, spawnPointGO.transform.position.y, 0.5f);
            ShowSprite(showCharacter);
        }
    }

    ///Target moves to specific position
    [YarnCommand("TargetMove")]
    public void TargetMove(float moveOffset, string goalName, bool isCharacterRemove)
    {
        var goalGameObject = GameObject.Find(goalName);

        if (goalGameObject)
        {
            var updatedMoveGoal_XValue = goalGameObject.transform.position.x + moveOffset;
            characterGO.transform.DOMoveX(updatedMoveGoal_XValue, tweenDuration, isTweenSnapOn);
            //If we want the character to disappear afterwards
            if (isCharacterRemove)
            {
                Toggle_CharacterActive(true);
            }
        }

        else
        {
            Debug.Log("Call TargetMove Command but no Goal");
        }
    }

    /// <summary>
    /// Target moves back to original spawned position
    /// </summary>
    /// <param name="isCharacterRemove">Should target be deactivated</param>
    [YarnCommand("TargetMove_Back")]
    public void TargetMove_Back(bool isCharacterRemove)
    {
        characterGO.transform.DOMoveX(character_OG_Pos.x, tweenDuration, isTweenSnapOn);
        //If we want the character to disappear afterwards
        if (isCharacterRemove)
        {
            Toggle_CharacterActive(true);
        }
    }

    ///Flip Sprite on X-axis
    [YarnCommand("FlipSprite")]
    private void FlipSprite()
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

    ///Dis/Enabled Sprite Renderer
    [YarnCommand("ShowSprite")]
    private void ShowSprite(bool showCharacter)
    {
        if (showCharacter)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    /// <summary>
    /// Set GameObject active or not
    /// </summary>
    /// <param name="toSetActive">Set target active?</param>
    [YarnCommand("Toggle_CharacterActive")]
    private void Toggle_CharacterActive(bool toSetActive)
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
