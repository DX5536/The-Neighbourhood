using UnityEngine;


public class ObjectHighlight: MonoBehaviour
{
    //[SerializeField]
    private SpriteRenderer objectSpriteRenderer;

    /*[SerializeField]
    private string playerTag = "Player";

    [Header("Sprite Materials")]
    [SerializeField]
    private Material spritesDefault_MAT;

    [SerializeField]
    private Material outline_MAT;*/

    [SerializeField]
    private ItemScriptableObject itemScribtableObject;

    void Start()
    {
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
        itemScribtableObject.SetIsInteractable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == itemScribtableObject.PlayerTag)
        {
            if (itemScribtableObject.IsInteractable)
            {
                //Debug.Log("Player Enter");
                objectSpriteRenderer.material = itemScribtableObject.Outline_MAT;
            }
            else
            {
                //Debug.Log("Item is blocked");
                objectSpriteRenderer.material = itemScribtableObject.Blocked_Outline_MAT;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == itemScribtableObject.PlayerTag)
        {
            //Debug.Log("Player Exit");
            objectSpriteRenderer.material = itemScribtableObject.SpritesDefault_MAT;
        }
    }
}