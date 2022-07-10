using UnityEngine;


public class SoundManager: MonoBehaviour
{
    //Make Sound Manager a singleton
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Tooltip("Insert soundScriptableObject to get AudioClip")]
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;

    [Header("Children AudioSource of SoundManager")]
    [SerializeField]
    private AudioSource BGM_AudioSource;

    [SerializeField]
    private AudioSource typingSFX_AudioSource;

    [SerializeField]
    private AudioSource walkingSFX_AudioSource;

    [SerializeField]
    private AudioSource item_AudioSource;

    private void Start()
    {
        BGM_AudioSource.clip = soundScriptableObject.BackgroundMusic;
        typingSFX_AudioSource.clip = soundScriptableObject.TypingSFX;
        walkingSFX_AudioSource.clip = soundScriptableObject.WalkingSFX;
        item_AudioSource.clip = soundScriptableObject.ItemSFX;

        //At start play BGM
        PlayBGM();
    }

    //All public methods to access from other scripts
    public void PlayBGM()
    {
        BGM_AudioSource.Play();
    }

    public void StopBGM()
    {
        BGM_AudioSource.Stop();
    }

    public void PlayTypingSFX()
    {
        typingSFX_AudioSource.Play();
    }

    //Walking
    public void PlayWalkingSFX()
    {
        walkingSFX_AudioSource.Play();
    }

    public void StopWalkingSFX()
    {
        walkingSFX_AudioSource.Stop();
    }

    public void PlayItemSFX()
    {
        item_AudioSource.Play();
    }

    //For option scene -> Changing the volumes
    //Master volume is all the sounds
    public void ChangeMasterVolume(float volumeValue)
    {
        AudioListener.volume = volumeValue;
    }

    public void ChangeBGMVolume(float volumeValue)
    {
        BGM_AudioSource.volume = volumeValue;
    }

    public void ChangeSFXVolume(float volumeValue)
    {
        walkingSFX_AudioSource.volume = volumeValue;
        typingSFX_AudioSource.volume = volumeValue;
        item_AudioSource.volume = volumeValue;
    }
}