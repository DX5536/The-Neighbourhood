using UnityEngine;


public class HUD_ArrowManager: MonoBehaviour
{
    //[Header("")]
    [SerializeField]
    private GameObject myHUDArrow;

    void Start()
    {

    }

    void Update()
    {
        myHUDArrow = GameObject.FindGameObjectWithTag("HUD_Arrow");
        if (myHUDArrow == null)
        {
            return;
        }
    }

    //public method as it's called upon L.Click
    public void SearchForHUD_Arrow()
    {

    }
}