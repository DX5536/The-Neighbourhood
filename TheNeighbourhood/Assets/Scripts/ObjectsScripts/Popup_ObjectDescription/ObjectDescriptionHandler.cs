using UnityEngine;


public class ObjectDescriptionHandler: MonoBehaviour
{
    /*[SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private string popUpItemID;*/

    [SerializeField]
    private ItemScriptableObject itemScribtableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == itemScribtableObject.PlayerTag)
        {
            //Debug.Log("Player Enter call Event " + this.name);
            ObjectDescriptionManager.PopupObjectDescription(itemScribtableObject.PopupItemID);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == itemScribtableObject.PlayerTag)
        {
            //Debug.Log("Player Enter");
            ObjectDescriptionManager.PopdownObjectDescription(itemScribtableObject.PopupItemID);
        }
    }
}