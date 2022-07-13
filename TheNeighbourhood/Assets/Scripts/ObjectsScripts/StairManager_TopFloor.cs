using System.Collections;
using UnityEngine;


public class StairManager_TopFloor: MonoBehaviour
{
    [Header("The chosen Stair_All of them")]
    [SerializeField]
    private GameObject[] chosenStair_Step;

    [Header("ONLY ENTER AMOUNT LIKE^")]
    [SerializeField]
    private BoxCollider2D[] chosenStepBoxCollider2D;

    void Start()
    {
        for (int i = 0;i < chosenStepBoxCollider2D.Length;i++)
        {
            chosenStepBoxCollider2D[i] = chosenStair_Step[i].GetComponent<BoxCollider2D>();

            StartCoroutine(SmallDelay());
            chosenStepBoxCollider2D[i].enabled = false;
        }
    }

    //If player start out at the top floor
    //Activate all stair collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0;i < chosenStepBoxCollider2D.Length;i++)
            {
                chosenStepBoxCollider2D[i].enabled = true;
            }
        }
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Finish Delay");

    }
}