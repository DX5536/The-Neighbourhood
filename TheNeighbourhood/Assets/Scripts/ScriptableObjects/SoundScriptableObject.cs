using UnityEngine;

[CreateAssetMenu(fileName = "Sound_SO", menuName = "ScriptableObject/SoundClips", order = 3)]
public class SoundScriptableObject: ScriptableObject
{
    [Header("BGM")]
    [Tooltip("BG music track.")]
    [SerializeField]
    private AudioClip backgroundMusic;

    public AudioClip BackgroundMusic
    {
        get
        {
            return backgroundMusic;
        }
    }

    [Header("SFX")]
    [Tooltip("SFX for Typing")]
    [SerializeField]
    private AudioClip typingSFX;

    public AudioClip TypingSFX
    {
        get
        {
            return typingSFX;
        }
    }

    [Tooltip("SFX for Walking")]
    [SerializeField]
    private AudioClip walkingSFX;

    public AudioClip WalkingSFX
    {
        get
        {
            return walkingSFX;
        }
    }

    [Tooltip("SFX for using/gaining Item")]
    [SerializeField]
    private AudioClip itemSFX;

    public AudioClip ItemSFX
    {
        get
        {
            return itemSFX;
        }
    }

}