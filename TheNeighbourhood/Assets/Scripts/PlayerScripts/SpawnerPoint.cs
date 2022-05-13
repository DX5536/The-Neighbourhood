using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
    [Header("Values READ_ONLY")]
    [SerializeField]
    private string playerTag = "Player";

    //[SerializeField]
    //private Transform nextSceneDoorTransform;

    [SerializeField]
    private string doorTag;

    [SerializeField]
    private SpawnerMaster spawnerMaster;

    private void Start()
    {
        spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
        doorTag = gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            spawnerMaster.LastDoorTag = doorTag;
            //spawnerMaster.LastSpawnPoint = nextSceneDoorTransform.position;
        }
    }
}
