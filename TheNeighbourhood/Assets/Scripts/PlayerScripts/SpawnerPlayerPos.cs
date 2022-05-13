using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayerPos : MonoBehaviour
{
    [SerializeField]
    private SpawnerMaster spawnerMaster;

    [SerializeField]
    private Transform savedDoorGO;

    private void Start()
    {
        spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
        //transform.position = spawnerMaster.LastSpawnPoint;
        savedDoorGO = GameObject.FindGameObjectWithTag(spawnerMaster.LastDoorTag).GetComponent<Transform>();

        if (savedDoorGO == null)
        {
            //If there is no savedDoorGO -> Spawn
            return;
        }

        else
        {
            //If there is a savedDoorGO -> Spawn
            transform.position = new Vector2(savedDoorGO.position.x, savedDoorGO.position.y);
        }
        


    }
}
