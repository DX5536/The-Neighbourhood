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

    [SerializeField]
    private AudioSource button_AudioSource;

    [SerializeField]
    private AudioSource hoverButton_AudioSource;

    private void Start()
    {
        BGM_AudioSource.clip = soundScriptableObject.BackgroundMusic;
        typingSFX_AudioSource.clip = soundScriptableObject.TypingSFX;
        walkingSFX_AudioSource.clip = soundScriptableObject.WalkingSFX;
        item_AudioSource.clip = soundScriptableObject.ItemSFX;
        //
        button_AudioSource.clip = soundScriptableObject.ButtonSFX;
        hoverButton_AudioSource.clip = soundScriptableObject.HoverButtonSFX;

        //Load the Music saved values from PlayerPref
        LoadVolumeValue();
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
        typingSFX_AudioSource.PlayOneShot(typingSFX_AudioSource.clip, 1);
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

    public void PlayButtonSFX()
    {
        button_AudioSource.Play();
    }

    public void PlayHoverButtonSFX()
    {
        hoverButton_AudioSource.Play();
    }

    //For option scene -> Changing the volumes
    //Master volume is all the sounds
    public void ChangeMasterVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("masterVolume", volumeValue);
        AudioListener.volume = volumeValue;
    }

    public void ChangeBGMVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("BGMVolume", volumeValue);
        BGM_AudioSource.volume = volumeValue;
    }

    public void ChangeSFXVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("SFXVolume", volumeValue);
        walkingSFX_AudioSource.volume = volumeValue;
        item_AudioSource.volume = volumeValue;
    }

    public void ChangeTypingSFXVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("TypingSFXVolume", volumeValue);
        //Typing is rather loud as default
        //So we make custom volume by multiple with volumeValue
        typingSFX_AudioSource.volume = volumeValue;
    }

    //This method will load from PlayerPref
    //And set the volumeValue as saved
    private void LoadVolumeValue()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        BGM_AudioSource.volume = PlayerPrefs.GetFloat("BGMVolume");

        var _SFX_SavedValue = PlayerPrefs.GetFloat("SFXVolume");
        walkingSFX_AudioSource.volume = _SFX_SavedValue;
        item_AudioSource.volume = _SFX_SavedValue;

        typingSFX_AudioSource.volume = PlayerPrefs.GetFloat("TypingSFXVolume");
        //In case there is no speaker/Dialogue System
        //Set default AudioClip to Lilly
        typingSFX_AudioSource.clip = soundScriptableObject.LillySFX;
    }
}