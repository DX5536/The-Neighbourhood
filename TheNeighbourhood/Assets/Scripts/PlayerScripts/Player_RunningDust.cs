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
        var ps_main = dust_PS.main;
        ps_main.duration = playerScriptableObject.TweenDurationProportionValue;

        dust_PS.Play();
    }
}