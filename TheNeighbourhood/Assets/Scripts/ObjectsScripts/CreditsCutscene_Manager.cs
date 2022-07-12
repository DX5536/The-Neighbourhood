using UnityEngine;
using UnityEngine.Events;

public class CreditsCutscene_Manager: MonoBehaviour
{
    [Header("Credits Cutscene")]
    [SerializeField]
    private Animator creditsAnimator;
    [SerializeField]
    private AnimationClip creditsClip;

    [SerializeField]
    private AnimationEvent animationEvent;

    [SerializeField]
    private UnityEvent stopPlayerEvent;

    void OnEnable()
    {
        creditsAnimator = GetComponent<Animator>();
        animationEvent = new AnimationEvent();
        animationEvent.functionName = "StopPlayerMovement";

        creditsClip = creditsAnimator.runtimeAnimatorController.animationClips[0];
        creditsClip.AddEvent(animationEvent);
    }

    void Update()
    {

    }

    public void StopPlayerMovement()
    {
        stopPlayerEvent?.Invoke();
    }
}