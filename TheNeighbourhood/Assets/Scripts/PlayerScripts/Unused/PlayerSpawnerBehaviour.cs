using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerBehaviour : MonoBehaviour
{
    //This will be the behavior
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform spawnPoint1;

    [SerializeField]
    private Transform spawnPoint2;

    private void Awake()
    {
        PlayerSpawnerManager.Instance.OnSpawnPointChanged += SpawnPlayerAtSpawnPoint1;
        PlayerSpawnerManager.Instance.OnSpawnPointChanged += SpawnPlayerAtSpawnPoint2;
    }

    private void OnDestroy()
    {
        PlayerSpawnerManager.Instance.OnSpawnPointChanged -= SpawnPlayerAtSpawnPoint1;
        PlayerSpawnerManager.Instance.OnSpawnPointChanged -= SpawnPlayerAtSpawnPoint2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayerAtSpawnPoint1(SpawnPointEnum newSpawnPoint)
    {
        enabled = newSpawnPoint == SpawnPointEnum.MyRoom;
    }

    private void SpawnPlayerAtSpawnPoint2(SpawnPointEnum newSpawnPoint)
    {
        enabled = newSpawnPoint == SpawnPointEnum.NPC_1_Room;
    }

    public void CheckLastDoorToSetSpawnPoint()
    {
        //Grab the last spawn point
        SpawnPointEnum currentSpawnpoint = PlayerSpawnerManager.Instance.CurrentSpawnPoint;

        //Check value
        SpawnPointEnum spawnPoint = currentSpawnpoint == SpawnPointEnum.MyRoom 
            ? SpawnPointEnum.MyRoom 
            : SpawnPointEnum.NPC_1_Room;
    }
}
