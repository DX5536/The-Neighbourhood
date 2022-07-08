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

        DestroyGO();
    }

    //public so we can force destroy in MouseClickPosition
    public void DestroyGO()
    {
        Destroy(parentGO);
    }
}