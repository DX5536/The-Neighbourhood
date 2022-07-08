using Assets.Scripts.ScriptableObjects;
using UnityEngine;


public class Player_RunningDust: MonoBehaviour
{
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;

    [Header("Dust_Particle System_READ_ONLY")]
    [SerializeField]
    private ParticleSystem dust_PS;

    void Start()
    {
        dust_PS = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }

    //Public Var to access with PlayerMovement
    public void CreateDust_PS()
    {

        dust_PS.Stop();

        var ps_main = dust_PS.main;
        //ps_main.duration = playerScriptableObject.TweenDurationProportionValue;
        ps_main.duration = 1f;

        dust_PS.Play();
    }
}