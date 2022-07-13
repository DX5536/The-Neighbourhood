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

        //Reset all volume back to 1 if no playerPref
        //Load the Music saved values from PlayerPref
        CheckPlayerPref_NewGame();
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
        if (typingSFX_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            typingSFX_AudioSource.PlayOneShot(typingSFX_AudioSource.clip, 1);
        }

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
        if (item_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            item_AudioSource.Play();
        }
    }

    public void PlayButtonSFX()
    {
        button_AudioSource.Play();
    }

    public void PlayHoverButtonSFX()
    {
        hoverButton_AudioSource.Play();
    }

    private void CheckPlayerPref_NewGame()
    {
        //If doesn't have  ANY of the key => Volume = 1
        if (!PlayerPrefs.HasKey("masterVolume") ||
            !PlayerPrefs.HasKey("BGMVolume") ||
            !PlayerPrefs.HasKey("SFXVolume") ||
            !PlayerPrefs.HasKey("TypingSFXVolume"))
        {
            AudioListener.volume = 1;
            BGM_AudioSource.volume = 1;
            walkingSFX_AudioSource.volume = 1;
            item_AudioSource.volume = 1;
            typingSFX_AudioSource.volume = 1;

            Debug.Log("No PlayerPref -> Reset all volume to 1");
        }

        else
        {
            LoadVolumeValue();
        }

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