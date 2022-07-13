using UnityEngine;
using Yarn.Unity;


public class YarnPostParticleEffectsController: MonoBehaviour
{
    [Header("Drama!")]
    [SerializeField]
    private GameObject blackAndWhiteEffect;

    [SerializeField]
    private GameObject rainEffect;

    void Start()
    {
        //Make sure these two at start to be inactive -> Only active upon call!
        blackAndWhiteEffect.SetActive(false);
        rainEffect.SetActive(false);
    }

    void Update()
    {

    }

    ///Turn on GlobalVolume = Post-Processing Effects
    [YarnCommand("SetGlobalVolumeActive")]
    public void SetGlobalVolumeActive(bool setActive)
    {
        if (setActive)
        {
            blackAndWhiteEffect.SetActive(true);
        }
        else
        {
            blackAndWhiteEffect.SetActive(false);
        }
    }

    ///Turn on Rain
    [YarnCommand("SetRainEffectActive")]
    public void SetRainEffectActive(bool setActive)
    {
        if (setActive)
        {
            rainEffect.SetActive(true);
        }
        else
        {
            rainEffect.SetActive(false);
        }
    }
}