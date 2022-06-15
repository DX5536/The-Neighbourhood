using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/PlayerValue", order = 3)]
    public class PlayerScriptableObject: ScriptableObject
    {
        [SerializeField]
        private Vector2 playerPositionValue;

        public Vector2 PlayerPositionValue
        {
            get
            {
                return playerPositionValue;
            }
            set
            {
                playerPositionValue = value;
            }
        }

        [Header("Player's DOTween")]

        [SerializeField]
        private float moveTweenDuration;

        [SerializeField]
        private bool moveTweenSnapping;

        [SerializeField]
        private Ease easeType;

        public float MoveTweenDuration
        {
            get => moveTweenDuration;
            //set => moveTweenDuration = value;
        }
        public bool MoveTweenSnapping
        {
            get => moveTweenSnapping;
            //set => moveTweenSnapping = value;
        }
        public Ease EaseType
        {
            get => easeType;
            //set => easeType = value;
        }

        public void RoundPlayerPositionValue()
        {
            playerPositionValue.x = Mathf.Round(playerPositionValue.x * 10f) / 10f;
            playerPositionValue.y = Mathf.Round(playerPositionValue.y * 10f) / 10f;
        }

    }
}