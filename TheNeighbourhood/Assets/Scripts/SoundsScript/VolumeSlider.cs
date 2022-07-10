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
}