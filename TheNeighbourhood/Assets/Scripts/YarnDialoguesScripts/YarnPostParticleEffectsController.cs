using UnityEngine;
using Yarn.Unity;


public class YarnPostParticleEffectsController: MonoBehaviour
{
    [Header("Drama!")]
    [SerializeField]
    private GameObject globalVolume;

    [SerializeField]
    private GameObject rainEffect;

    void Start()
    {
        //Make sure these two at start to be inactive -> Only active upon call!
        globalVolume.SetActive(false);
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
            globalVolume.SetActive(true);
        }
        else
        {
            globalVolume.SetActive(false);
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