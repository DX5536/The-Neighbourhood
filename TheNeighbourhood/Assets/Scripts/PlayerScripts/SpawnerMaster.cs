using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerMaster : MonoBehaviour
{
    //Make this a singleton
    private static SpawnerMaster instance;

    private void Awake()
    {
        //Create an instance
        if (instance != null)
        {
            Debug.Log("There are more than 1 " + this.gameObject.name + " value.");
            Destroy(this.gameObject);
        }

        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    [Header("For the special case of Player starting from above")]
    [SerializeField]
    private string spawnPoint_NPC_1 = "Door_NPC_1";
    [SerializeField]
    private UnityEvent vCameraPosAtSpawn;

    [Header("Values READ_ONLY")]
    [SerializeField]
    private Vector2 lastSpawnPoint;
    [SerializeField]
    private string lastDoorTag;

    public Vector2 LastSpawnPoint
    {
        get { return lastSpawnPoint; }
        set { lastSpawnPoint = value; }
    }

    public string LastDoorTag
    {
        get { return lastDoorTag; }
        set { lastDoorTag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (lastDoorTag == spawnPoint_NPC_1)
        {
            vCameraPosAtSpawn?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
