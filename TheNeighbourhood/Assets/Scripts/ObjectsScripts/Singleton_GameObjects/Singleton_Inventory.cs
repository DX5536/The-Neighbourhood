using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton_Inventory: MonoBehaviour
{
    [SerializeField]
    private int menuSceneIndex;

    //Make this a singleton
    private static Singleton_Inventory instance;

    private void Awake()
    {
        //Create an instance
        if (instance != null)
        {
            //Debug.Log("There are more than 1 " + this.gameObject.name + " value.");
            Destroy(this.gameObject);
        }

        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += DestroyOnMenu;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= DestroyOnMenu;

    }

    private void DestroyOnMenu(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex != menuSceneIndex)
        {
            return;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("On Menu -> Del Canvas");
        }
    }
}