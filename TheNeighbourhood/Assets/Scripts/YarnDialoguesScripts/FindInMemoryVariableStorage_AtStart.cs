using UnityEngine;
using Yarn.Unity;

public class FindInMemoryVariableStorage_AtStart : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [Header("READ_ONLY")]
    [SerializeField]
    private InMemoryVariableStorage storage;

    /*public InMemoryVariableStorage Storage
    {
        get { return storage; }
    }*/

    private void Start()
    {
        //First find the storage by tag (cuz I need the storage in non-DialogRunner too)
        storage = FindObjectOfType<InMemoryVariableStorage>();

        if (storage != null)
        {
            //Put the value inside DialogRunner
            dialogueRunner.VariableStorage = storage;
        }
        else
        {
            Debug.Log("There is no VariableStorage");
        }
    }
}