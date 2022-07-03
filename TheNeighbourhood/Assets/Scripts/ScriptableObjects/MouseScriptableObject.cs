using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/MouseValue", order = 2)]
    public class MouseScriptableObject: ScriptableObject
    {
        [Header("Reset the status of canClickMouse at Awake()")]
        [SerializeField]
        private bool resetCanClickMouseAtStart;

        [SerializeField]
        private bool canClickMouse;

        public bool CanClickMouse
        {
            get
            {
                return canClickMouse;
            }
            set
            {
                canClickMouse = value;
            }
        }

        [SerializeField]
        private Vector2 mousePositionValue;

        public Vector2 MousePositionValue
        {
            get
            {
                return mousePositionValue;
            }
            set
            {
                mousePositionValue = value;
            }
        }

        [SerializeField]
        private Vector2 raycastHitValue;

        public Vector2 RaycastHitValue
        {
            get
            {
                return raycastHitValue;
            }
            set
            {
                raycastHitValue = value;
            }
        }

        [Header("Spawn small display arrow")]
        [Tooltip("Player_SO so we can access tweenDurationProportionValue")]
        [SerializeField]
        private PlayerScriptableObject playerScriptableObject;

        [SerializeField]
        private GameObject arrowHUDImage;

        public GameObject ArrowHUDImage
        {
            get
            {
                return arrowHUDImage;
            }
            set
            {
                arrowHUDImage = value;
            }
        }

        [SerializeField]
        private float arrowDisplayTime;

        public float ArrowDisplayTime
        {
            get => arrowDisplayTime;
            set => arrowDisplayTime = value;
        }

        [SerializeField]
        private bool arrowHasSpawned;

        public bool ArrowHasSpawned
        {
            get
            {
                return arrowHasSpawned;
            }
            set
            {
                arrowHasSpawned = value;
            }
        }

        public void RoundMousePositionValue()
        {
            mousePositionValue.x = Mathf.Round(mousePositionValue.x * 10f) / 10f;
            mousePositionValue.y = Mathf.Round(mousePositionValue.y * 10f) / 10f;
        }

        public void RoundRaycastHitValue()
        {
            raycastHitValue.x = Mathf.Round(raycastHitValue.x * 10f) / 10f;
            raycastHitValue.y = Mathf.Round(raycastHitValue.y * 10f) / 10f;
        }

        public void DisplayHUDImage()
        {
            //If Arrow hasn't spawn yet -> Allow to spawn
            if (arrowHasSpawned == false)
            {
                SetImageDisplayTime_ToProportionValue();

                Instantiate(arrowHUDImage, new Vector2(raycastHitValue.x, raycastHitValue.y), arrowHUDImage.transform.rotation);
                arrowHasSpawned = true;
            }
            //Else
        }

        private void SetImageDisplayTime_ToProportionValue()
        {
            //Set the HUD_Arrow displayed time to the amount the player needs to get to it
            arrowDisplayTime = playerScriptableObject.TweenDurationProportionValue;
        }

        public void SetCanClickMouse()
        {
            if (resetCanClickMouseAtStart)
            {
                canClickMouse = true;
                //Debug.Log("Reset isInteractable");
            }
            else
            {
                canClickMouse = false;
            }
        }
    }
}