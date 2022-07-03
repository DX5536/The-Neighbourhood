using UnityEngine;


public class Singleton_Inventory: MonoBehaviour
{
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
}