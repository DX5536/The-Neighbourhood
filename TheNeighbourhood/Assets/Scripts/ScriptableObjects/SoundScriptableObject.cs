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

    [Header("Typing SFX")]
    [SerializeField]
    private AudioClip lillySFX;

    public AudioClip LillySFX
    {
        get
        {
            return lillySFX;
        }
        set
        {
            lillySFX = value;
        }
    }

    [SerializeField]
    private AudioClip carolineSFX;

    public AudioClip CarolineSFX
    {
        get
        {
            return carolineSFX;
        }
        set
        {
            carolineSFX = value;
        }
    }

    [SerializeField]
    private AudioClip malkaSFX;

    public AudioClip MalkaSFX
    {
        get
        {
            return malkaSFX;
        }
        set
        {
            malkaSFX = value;
        }
    }

    [SerializeField]
    private AudioClip amonSFX;

    public AudioClip AmonSFX
    {
        get
        {
            return amonSFX;
        }
        set
        {
            amonSFX = value;
        }
    }

    [SerializeField]
    private AudioClip tomSFX;

    public AudioClip TomSFX
    {
        get
        {
            return tomSFX;
        }
        set
        {
            tomSFX = value;
        }
    }

    [SerializeField]
    private AudioClip birdSFX;

    public AudioClip BirdSFX
    {
        get
        {
            return birdSFX;
        }
        set
        {
            birdSFX = value;
        }
    }

    [SerializeField]
    private AudioClip squirrelSFX;

    public AudioClip SquirrelSFX
    {
        get
        {
            return squirrelSFX;
        }
        set
        {
            squirrelSFX = value;
        }
    }

}