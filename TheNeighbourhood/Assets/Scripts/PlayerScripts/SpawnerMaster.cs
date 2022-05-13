using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMaster : MonoBehaviour
{
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

    //Make it Singleton
    private static SpawnerMaster instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
