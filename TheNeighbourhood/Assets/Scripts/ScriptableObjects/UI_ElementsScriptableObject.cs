using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/UI_Elements", order = 4)]
public class UI_ElementsScriptableObject: ScriptableObject
{
    [Header("DOTween")]
    [SerializeField]
    private float tweenDuration;

    [SerializeField]
    private bool tweenSnapping;

    [SerializeField]
    private Ease easeType;

    [SerializeField]
    private float tweenDelaySeconds;

    public float TweenDelaySeconds
    {
        get
        {
            return tweenDelaySeconds;
        }
        set
        {
            tweenDelaySeconds = value;
        }
    }


    public float TweenDuration
    {
        get => tweenDuration;
        set => tweenDuration = value;
    }
    public bool TweenSnapping
    {
        get => tweenSnapping;
        set => tweenSnapping = value;
    }
    public Ease EaseType
    {
        get => easeType;
        set => easeType = value;
    }

}