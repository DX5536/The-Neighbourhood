using DG.Tweening;
using TMPro;
using UnityEngine;


public class ObjectDescriptionBehaviour: MonoBehaviour
{
    [Header("Description GO; NOT CANVAS GAMEOBJECT!!!")]
    [SerializeField]
    private GameObject descriptionGO;
    /*[SerializeField]
    private string objectName;

    [Header("Follow Scene Switcher's names")]
    [SerializeField]
    private string popUpItemID;*/

    //[Header("READ_Only")]
    //[SerializeField]
    private Vector2 objectStartingPosition;
    //[SerializeField]
    private RectTransform objectRectTransform;

    /*[Header("DOTween")]
    [SerializeField]
    private float anchoredTween_YValue;
    [SerializeField]
    private float tweenDuration = 0.5f;
    [SerializeField]
    private bool tweenSnapping = false;*/

    //We using Scriptable Object now!
    [SerializeField]
    private ItemScriptableObject itemScribtableObject;

    private void OnEnable()
    {
        ObjectDescriptionManager.onPopupObjectDescription += PopupDescriptionDOTween;
        ObjectDescriptionManager.onPopdownObjectDescription += PopdownDescriptionDOTween;
    }

    private void OnDisable()
    {
        ObjectDescriptionManager.onPopupObjectDescription -= PopupDescriptionDOTween;
        ObjectDescriptionManager.onPopdownObjectDescription -= PopdownDescriptionDOTween;
    }

    void Start()
    {
        descriptionGO.SetActive(false);

        objectRectTransform = descriptionGO.GetComponent<RectTransform>();
        objectStartingPosition = new Vector2(objectRectTransform.anchoredPosition.x, objectRectTransform.anchoredPosition.y);
    }

    void Update()
    {

    }

    private void PopupDescriptionDOTween(string popUpItemID)
    {
        if (popUpItemID == itemScribtableObject.PopupItemID)
        {
            //Debug.Log("PopUp event has been called");
            descriptionGO.SetActive(true);

            var objectTMP = descriptionGO.GetComponent<TextMeshProUGUI>();
            objectTMP.text = itemScribtableObject.PopupDescription;

            var currentAnchorYValue = objectRectTransform.anchoredPosition.y;
            //Description move Up
            objectRectTransform.DOAnchorPosY(
                currentAnchorYValue + itemScribtableObject.TweenValue,
                itemScribtableObject.TweenDuration,
                itemScribtableObject.TweenSnapping);
        }

    }

    private void PopdownDescriptionDOTween(string popUpItemID)
    {
        if (popUpItemID == itemScribtableObject.PopupItemID)
        {
            //Move back to Starting Position 
            objectRectTransform.DOAnchorPosY(
                objectStartingPosition.y,
                itemScribtableObject.TweenDuration,
                itemScribtableObject.TweenSnapping)
                .OnComplete(() => descriptionGO.SetActive(false));
        }
    }
}