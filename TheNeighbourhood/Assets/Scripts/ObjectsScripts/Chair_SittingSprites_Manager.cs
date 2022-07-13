using UnityEngine;
using Yarn.Unity;

public class Chair_SittingSprites_Manager: MonoBehaviour
{
    [Header("Empty Chair/Table")]
    [SerializeField]
    private GameObject[] chairGameObjects;

    [Header("SittingSprites/Table with food")]
    [SerializeField]
    private GameObject[] sittingSpritesGameObject;

    [Header("The characters's Sprite Renderer")]
    [SerializeField]
    private SpriteRenderer[] characterSpriteRenderers;

    [Header("The Grandparents' BoxCollider")]
    [SerializeField]
    private BoxCollider2D[] grandparentsBoxCollider;

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

    /// <summary>
    /// Toggle grandparents' BoxCollider (for popup/StartYarnNode/etc.)
    /// </summary>
    /// <param name="isEnabled"></param>
    [YarnCommand("Toggle_BoxCollider2D")]
    private void Toggle_BoxCollilder2D(bool isEnabled)
    {
        for (int i = 0;i < grandparentsBoxCollider.Length;i++)
        {
            grandparentsBoxCollider[i].enabled = isEnabled;
        }

    }

    [YarnCommand("SittingSprites")]
    private void SittingSprites()
    {
        //Make sure player is in the Chair_Lilly Position
        player.transform.position = lillyChair.transform.position;

        //Disable the Sprite Renderer Component of the 3 characters
        for (int i = 0;i < characterSpriteRenderers.Length;i++)
        {
            characterSpriteRenderers[i].enabled = false;
        }

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