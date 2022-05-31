using UnityEngine;

public class Inventory_CameraMovement : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private Transform cameraAnchor;

    //[Header("DOTween's Value")]
    //[SerializeField]
    private float tweenDuration;

    [Header("Look For Inventory: READ_ONLY")]
    [SerializeField]
    private Vector3 cameraAnchorWorld;

    [SerializeField]
    private GameObject inventory;

    [SerializeField]
    private Transform inventoryTransform;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventoryTransform = inventory.GetComponent<Transform>();
    }

    private void Update()
    {
        cameraAnchorWorld = cameraAnchor.TransformPoint(cameraAnchor.position);

        inventoryTransform.position = new Vector3(0 , cameraAnchorWorld.y * 0.5f , 0);

        //Do Move is harder as testing TweenValue is time consuming
        //inventory.transform.DOMoveY(cameraAnchorWorld.y * 0.5f , tweenDuration);
    }
}