using UnityEngine;


public class Singleton_InMemoryVariableStorage: MonoBehaviour
{
    //Make this a singleton
    private static Singleton_InMemoryVariableStorage instance;

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