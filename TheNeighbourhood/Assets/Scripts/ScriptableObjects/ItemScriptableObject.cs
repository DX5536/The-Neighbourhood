using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/InteractableItem", order = 1)]
public class ItemScriptableObject: ScriptableObject
{
    [Header("Reset the status of isInteractable at Awake()")]
    [Header("NPC/Item should NOT interactable at start -> Collider = interactable")]
    [SerializeField]
    private bool resetIsInteractableAtStart;

    [Header("Collider_playerTag")]
    private string playerTag = "Player";

    [SerializeField]
    private bool isInteractable;

    [Header("Highlight Material")]
    [SerializeField]
    private Material spritesDefault_MAT;

    [SerializeField]
    private Material outline_MAT;

    [SerializeField]
    private Material blocked_Outline_MAT;

    [Header("Description Pop-up")]
    [SerializeField]
    private string popupItemID;

    [SerializeField]
    private string popupDescription;

    [Header("DOTween")]
    [SerializeField]
    private float tweenValue;

    [SerializeField]
    private float tweenDuration;

    [SerializeField]
    private bool tweenSnapping;

    [SerializeField]
    private Ease easeType;

    [Header("Yarn Start Node")]
    [SerializeField]
    private string nodeName;

    [Header("Speaker's Color -> NPC_ONLY")]
    [SerializeField]
    private Color speakerNPC_Color;

    public Color SpeakerNPC_Color
    {
        get
        {
            return speakerNPC_Color;
        }
    }

    [SerializeField]
    private Color32 textBox_Color;

    public Color32 TextBox_Color
    {
        get
        {
            return textBox_Color;
        }
        set
        {
            textBox_Color = value;
        }
    }

    public bool ResetIsInteractableAtStart
    {
        get => resetIsInteractableAtStart;
    }

    //Properties
    public string PlayerTag
    {
        get => playerTag;
    }

    public bool IsInteractable
    {
        get => isInteractable;
        set => isInteractable = value;
    }

    //Material
    public Material SpritesDefault_MAT
    {
        get => spritesDefault_MAT;
    }

    public Material Outline_MAT
    {
        get => outline_MAT;
    }

    public Material Blocked_Outline_MAT
    {
        get => blocked_Outline_MAT;
    }

    //Pop-up
    public string PopupItemID
    {
        get => popupItemID;
    }

    public string PopupDescription
    {
        get => popupDescription;
    }

    //Tween
    public float TweenValue
    {
        get => tweenValue;
    }

    public float TweenDuration
    {
        get => tweenDuration;
    }

    public bool TweenSnapping
    {
        get => tweenSnapping;
    }

    public Ease EaseType
    {
        get => easeType;
    }

    public string NodeName
    {
        get => nodeName;
    }

    public void SetIsInteractable()
    {
        if (resetIsInteractableAtStart)
        {
            isInteractable = true;
            //Debug.Log("Reset isInteractable");
        }
        else
        {
            isInteractable = false;
        }
    }
}