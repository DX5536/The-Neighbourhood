using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider: MonoBehaviour
{
    [Header("Master Volume (all sounds)")]
    [SerializeField]
    private Slider masterVolumeSlider;

    [Header("BGM Volume (only BGM)")]
    [SerializeField]
    private Slider _BGMVolumeSlider;

    [Header("SFX Volume (walking, item)")]
    [SerializeField]
    private Slider _SFXVolumeSlider;

    [Header("Typing SFX Volume")]
    [SerializeField]
    private Slider typingSFXVolumeSlider;
    void Start()
    {
        //Check if there is any key, no sliders = 1
        //Else Load all the saved values to the sliders' values
        CheckValues_VolumeValue();

        //Then subscribe volume change (and saved value on each change)
        //To OnValueChanged() Unity Event in each slider
        masterVolumeSlider.onValueChanged.AddListener
            (
                val => SoundManager.instance.ChangeMasterVolume(val)
            );

        _BGMVolumeSlider.onValueChanged.AddListener
            (
            val => SoundManager.instance.ChangeBGMVolume(val)
            );

        typingSFXVolumeSlider.onValueChanged.AddListener
            (
            val => SoundManager.instance.ChangeTypingSFXVolume(val)
            );

        _SFXVolumeSlider.onValueChanged.AddListener
            (
            val => SoundManager.instance.ChangeSFXVolume(val)
            );


    }

    private void CheckValues_VolumeValue()
    {
        //If doesn't have  ANY of the key => Volume = 1
        if (!PlayerPrefs.HasKey("masterVolume") ||
            !PlayerPrefs.HasKey("BGMVolume") ||
            !PlayerPrefs.HasKey("SFXVolume") ||
            !PlayerPrefs.HasKey("TypingSFXVolume"))
        {
            masterVolumeSlider.value = 1;
            _BGMVolumeSlider.value = 1;
            typingSFXVolumeSlider.value = 1;
            _SFXVolumeSlider.value = 1;

            Debug.Log("No PlayerPref -> Reset sliders to 1");
        }

        else
        {
            LoadSliders_VolumeValue();
        }
    }

    private void LoadSliders_VolumeValue()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        _BGMVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        typingSFXVolumeSlider.value = PlayerPrefs.GetFloat("TypingSFXVolume");
        _SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");

    }

}