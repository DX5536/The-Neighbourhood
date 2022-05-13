using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerManager
{
    //Make it Singleton
    private static PlayerSpawnerManager instance;
    public static PlayerSpawnerManager Instance
    {
        get
        {
            if (instance == null)

                instance = new PlayerSpawnerManager();

            return instance;

        }
    }

    public SpawnPointEnum CurrentSpawnPoint
    {
        get;
        private set;
    }

    //Set up delegate eg. Custom Event
    public delegate void PlayerSpawnerEvent (SpawnPointEnum newSpawnPoint);
    //Set up event
    public event PlayerSpawnerEvent OnSpawnPointChanged;

    public void SetSpawnPoint (SpawnPointEnum newSpawnPoint)
    {
        if (newSpawnPoint == CurrentSpawnPoint)
        {
            return;
        }

        CurrentSpawnPoint = newSpawnPoint;
        OnSpawnPointChanged.Invoke(newSpawnPoint);
    }
}
