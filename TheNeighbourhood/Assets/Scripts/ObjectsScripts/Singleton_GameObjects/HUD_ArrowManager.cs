using UnityEngine;


public class HUD_ArrowManager: MonoBehaviour
{
    [Header("Update_AutoSearch")]
    [SerializeField]
    private GameObject myHUDArrow;

    void Start()
    {

    }

    void FixedUpdate()
    {
        myHUDArrow = GameObject.FindGameObjectWithTag("HUD_Arrow");
        if (myHUDArrow == null)
        {
            return;
        }

        SearchForHUD_Arrow();
    }

    //public method as it's called upon L.Click
    public void SearchForHUD_Arrow()
    {
        //First we check if there is a current HUD_Arrow present
        //If there is one:
        if (myHUDArrow)
        {
            //If we click L.Mouse when a HUD_Arrow is already present.
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Player click to new position while HUD still present");
            }
        }

        else
        {
            Debug.Log("There is no HUD_Arrow");
        }
    }
}