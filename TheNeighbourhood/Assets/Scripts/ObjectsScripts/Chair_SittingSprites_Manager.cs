using UnityEngine;
using Yarn.Unity;

public class Chair_SittingSprites_Manager: MonoBehaviour
{
    [Header("Chair")]
    [SerializeField]
    private GameObject[] chairGameObjects;

    [Header("SittingSprites")]
    [SerializeField]
    private GameObject[] sittingSpritesGameObject;

    [SerializeField]
    private GameObject lillyChair;

    [Header("READ_ONLY")]
    [SerializeField]
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //At start make sure all SittingSprites are inactive
        for (int i = 0;i < sittingSpritesGameObject.Length;i++)
        {
            sittingSpritesGameObject[i].SetActive(false);
        }

        //And all ChairSprites are active
        for (int i = 0;i < chairGameObjects.Length;i++)
        {
            chairGameObjects[i].SetActive(true);
        }
    }

    void Update()
    {

    }

    [YarnCommand("SittingSprites")]
    private void SittingSprites()
    {
        //Make sure player is in the Chair_Lilly Position
        player.transform.position = lillyChair.transform.position;

        //First deactivate all the chairGameobjects
        for (int i = 0;i < chairGameObjects.Length;i++)
        {
            chairGameObjects[i].SetActive(false);
        }

        //Then activate all the Sitting Sprites
        for (int i = 0;i < sittingSpritesGameObject.Length;i++)
        {
            sittingSpritesGameObject[i].SetActive(true);
        }
    }
}