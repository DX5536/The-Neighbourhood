using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/MouseValue", order = 2)]
    public class MouseScriptableObject: ScriptableObject
    {
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
    }
}