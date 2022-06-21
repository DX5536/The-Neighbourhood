using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerMaster: MonoBehaviour
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

    //[SerializeField]
    //private int cameraID;

    //[SerializeField]
    //private UnityEvent vCameraPosAtSpawn;

    [Header("Values READ_ONLY")]
    [SerializeField]
    private Vector2 lastSpawnPoint;

    [SerializeField]
    private string lastDoorTag;

    public Vector2 LastSpawnPoint
    {
        get
        {
            return lastSpawnPoint;
        }
        set
        {
            lastSpawnPoint = value;
        }
    }

    public string LastDoorTag
    {
        get
        {
            return lastDoorTag;
        }
        set
        {
            lastDoorTag = value;
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += UseCam_00;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= UseCam_00;
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    private void UseCam_00(Scene currentScene, Scene nextScene)
    {
        if (lastDoorTag == spawnPoint_NPC_1)
        {
            //vCameraPosAtSpawn?.Invoke(); //This is to use Unity event but sadly the Cinemachine is destroyed upon load scene
            CameraEventManager.NPC_1CameraPos();
        }
    }
}