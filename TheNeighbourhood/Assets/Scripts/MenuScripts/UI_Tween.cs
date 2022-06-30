using System.Collections;
using DG.Tweening;
using UnityEngine;


public class UI_Tween: MonoBehaviour
{
    [Header("UI_SO to access Tween value")]
    [SerializeField]
    private UI_ElementsScriptableObject _UI_ElementsScriptableObject;

    [Header("Objects to be tween")]
    [SerializeField]
    private RectTransform myUI_Rect;
    private float currentTweenDelay;

    [Header("_READ_ONLY > Press T to tess MoveUIBackToOG")]
    [SerializeField]
    private RectTransform myGoal_Rect;
    [SerializeField]
    private Vector2 myUI_OGPos;

    void Start()
    {
        myUI_OGPos = myUI_Rect.anchoredPosition;
        myGoal_Rect = this.GetComponent<RectTransform>();
        currentTweenDelay = _UI_ElementsScriptableObject.TweenDelaySeconds;

        StartCoroutine(DelayTween_MoveUIRight());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MoveUIBackToOG();
        }
    }

    public void MoveUIBackToOG()
    {
        myUI_Rect.DOAnchorPosX(myUI_OGPos.x,
            _UI_ElementsScriptableObject.TweenDuration,
            _UI_ElementsScriptableObject.TweenSnapping);
    }

    private IEnumerator DelayTween_MoveUIRight()
    {
        //Check for delay first then Tween
        yield return new WaitForSeconds(currentTweenDelay);
        myUI_Rect.DOAnchorPosX(myGoal_Rect.anchoredPosition.x,
            _UI_ElementsScriptableObject.TweenDuration,
            _UI_ElementsScriptableObject.TweenSnapping);
    }
}