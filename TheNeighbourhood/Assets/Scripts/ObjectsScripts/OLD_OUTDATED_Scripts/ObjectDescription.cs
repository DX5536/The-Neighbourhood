using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ObjectDescription : MonoBehaviour
{
    [Header("Objects needs TriggerCollider to have description")]
    [SerializeField]
    private GameObject descriptionGO;
    [SerializeField]
    private string objectName;
    [SerializeField]
    private string playerTag = "Player";

    [Header("Important Components_READ ONLY")]
    [SerializeField]
    private TextMeshProUGUI objectTMP;
    [SerializeField]
    private RectTransform objectRectTransform;

    private float currentAnchorYValue;

    [Header("DEBUG VALUE_READ ONLY")]
    [SerializeField]
    private Vector2 objectStartingPosition;
    [SerializeField]
    private Vector2 objectCurrentPosition;

    [Header("DOTween")]
    [SerializeField]
    private float anchoredTween_YValue;
    [SerializeField]
    private float tweenDuration = 0.5f;
    [SerializeField]
    private bool tweenSnapping = false;

    

    // Start is called before the first frame update
    void Start()
    {
        //Make sure all description is inactive at start -> Human are dumb
        descriptionGO.SetActive(false);
        //Get important stuff
        objectRectTransform = descriptionGO.GetComponent<RectTransform>();
        objectTMP = descriptionGO.GetComponent<TextMeshProUGUI>();

        objectStartingPosition = new Vector2(objectRectTransform.anchoredPosition.x, objectRectTransform.anchoredPosition.y);
    }


    // Update is called once per frame
    void Update()
    {
        objectCurrentPosition = new Vector2(objectRectTransform.anchoredPosition.x , objectRectTransform.anchoredPosition.y);
        currentAnchorYValue = objectRectTransform.anchoredPosition.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            descriptionGO.SetActive(true);
            objectTMP.text = objectName;

            //Description move Up
            objectRectTransform.DOAnchorPosY(currentAnchorYValue + anchoredTween_YValue , tweenDuration , tweenSnapping);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Description move Down -> Deactivate AFTER TWEEN
            objectRectTransform.DOAnchorPosY(objectStartingPosition.y , tweenDuration , tweenSnapping)
                .OnComplete(() => descriptionGO.SetActive(false));  
        }
    }
}
