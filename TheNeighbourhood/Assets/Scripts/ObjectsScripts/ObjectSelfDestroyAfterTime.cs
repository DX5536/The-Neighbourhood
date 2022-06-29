using System.Collections;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

public class ObjectSelfDestroyAfterTime: MonoBehaviour
{
    [SerializeField]
    private MouseScriptableObject mouseScriptableObject;

    [Header("READ_ONLY")]
    [SerializeField]
    private GameObject parentGO;

    private void Start()
    {
        parentGO = this.transform.parent.gameObject;
        StartCoroutine(SelfDestroyAfterSeconds());
    }

    IEnumerator SelfDestroyAfterSeconds()
    {
        yield return new WaitForSeconds(mouseScriptableObject.ArrowDisplayTime);

        Destroy(parentGO);
    }
}