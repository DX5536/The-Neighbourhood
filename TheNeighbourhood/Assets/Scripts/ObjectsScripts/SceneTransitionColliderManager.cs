using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class SceneTransitionColliderManager: MonoBehaviour
{
    //[Header("")]
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private ItemScriptableObject doorScriptableObject;

    [SerializeField]
    private string keyToPress_DEBUG = "e";

    [SerializeField]
    private float spamKeyDelay = 2;

    //[SerializeField]
    private bool canSwitchScene = false;

    private float timer;

    void Start()
    {

    }

    void Update()
    {
        //Anti-Spam [E] Key when standing on Door
        timer += Time.deltaTime;
        if (timer >= spamKeyDelay)
        {
            if (Input.GetKeyDown(keyToPress_DEBUG) && canSwitchScene == true && doorScriptableObject.IsInteractable)
            {
                //Debug.Log("Switch Scene");
                ToOpenDoor();
            }
            timer = spamKeyDelay;
        }

        else
        {
            //Debug.Log("Key on cooldown!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player can go out!");
            canSwitchScene = true;
        }

    }

    ///Transition the player into another room, scene
    [YarnCommand("ToOpenDoor")]
    void ToOpenDoor()
    {
        var doorInteractable = this.gameObject.GetComponent<IDoorInteractable>();
        if (doorInteractable == null)
        {
            Debug.Log("There is no IDoorInterface");
            return;
        }

        else
        {
            StartCoroutine(SmallDelay());
            doorInteractable.OpenDoor();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            //Debug.Log("Player can go out!");
            canSwitchScene = false;
        }
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Finish Delay");

    }

}