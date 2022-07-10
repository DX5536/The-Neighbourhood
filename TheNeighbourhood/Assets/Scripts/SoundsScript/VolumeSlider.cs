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

    [Header("SFX Volume (walking, typing, item)")]
    [SerializeField]
    private Slider _SFXVolumeSlider;
    void Start()
    {
        //First Load all the saved values to the sliders' values
        LoadSliders_VolumeValue();

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

        _SFXVolumeSlider.onValueChanged.AddListener
            (
            val => SoundManager.instance.ChangeSFXVolume(val)
            );
    }

    private void LoadSliders_VolumeValue()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        _BGMVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        _SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

}