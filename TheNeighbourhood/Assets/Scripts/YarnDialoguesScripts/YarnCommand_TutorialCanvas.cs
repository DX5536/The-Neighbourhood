using UnityEngine;
using Yarn.Unity;

public class YarnCommand_TutorialCanvas: MonoBehaviour
{
    [Header("TutorialCanvas")]
    [SerializeField]
    private GameObject tutorialCanvas;

    void Start()
    {
        //Make sure this canvas always deactivate at start regardless.
        tutorialCanvas.SetActive(false);
    }

    ///Activate Tutorial_Canvas or not
    /// active = turn it on or not.
    [YarnCommand("De_ActivateTutorialCanvas")]
    private void De_ActivateTutorialCanvas(bool active)
    {
        //If active = set canvas active
        if (active)
        {
            tutorialCanvas.SetActive(true);
        }

        else
        {
            tutorialCanvas.SetActive(false);
        }
    }
}