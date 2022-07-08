using Assets.Scripts.ScriptableObjects;
using UnityEngine;


public class Player_RunningDust: MonoBehaviour
{
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;

    [Header("Dust_Particle System")]
    [SerializeField]
    private ParticleSystem dust_PS;

    void Start()
    {
        dust_PS = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }

    //Public method to access in MouseClickPosition.SwitchAnimtion_Based_IsRunning()
    //Which based on the presence of HUD_Arrow or not.
    public void StopDust_PS()
    {
        dust_PS.Stop();
    }

    //Public method to access in MouseClickPosition.SwitchAnimtion_Based_IsRunning()
    //Which based on the presence of HUD_Arrow or not.
    public void CreateDust_PS()
    {
        if (dust_PS.isPlaying == false)
        {
            //Stop the dust temporary
            dust_PS.Stop();
            var ps_main = dust_PS.main;
            //Assign new duration -> 100sec to make sure dust will never go out unless called!
            ps_main.duration = 100f;

            dust_PS.Play();
            //Debug.Log("Dust_PS is not playing -> start playing");
        }

        else
        {
            //Debug.Log("Dust_PS is currently playing.");
            return;
        }

    }
}