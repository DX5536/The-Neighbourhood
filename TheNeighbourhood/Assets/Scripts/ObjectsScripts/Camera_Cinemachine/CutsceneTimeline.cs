using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTimeline: MonoBehaviour
{
    [Header("Director")]
    [SerializeField]
    private PlayableDirector director;

    [SerializeField]
    private GameObject cutsceneCanvas;
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnDestroy()
    {
    }

    public void PlayTimelineDirector()
    {
        director.Play();
        Debug.Log("Play Timeline");
    }


}