using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayerPos : MonoBehaviour
{
    [Header("Values READ_ONLY")]
    [SerializeField]
    private SpawnerMaster spawnerMaster;

    [SerializeField]
    private Transform savedDoorGO;


    private void Start()
    {
        spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
        //transform.position = spawnerMaster.LastSpawnPoint;
        savedDoorGO = GameObject.FindGameObjectWithTag(spawnerMaster.LastDoorTag).GetComponent<Transform>();

        if (!savedDoorGO)
        {
            //If there is no savedDoorGO -> Spawn
            Debug.Log("There is no savedDoor");
            return;
        }

        else
        {
            //If there is a savedDoorGO -> Spawn
            StartCoroutine(WaitForSpawnMaster());
            transform.position = new Vector2(savedDoorGO.position.x , savedDoorGO.position.y);
        }


    }

    private IEnumerator WaitForSpawnMaster()
    {
        //Wait for at least 1 sec for all set up, then spawn Player
        yield return new WaitForSeconds(1);
        
    }
}
