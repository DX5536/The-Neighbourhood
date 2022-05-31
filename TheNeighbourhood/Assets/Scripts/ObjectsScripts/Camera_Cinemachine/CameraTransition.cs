using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Cinemachine;


public class CameraTransition : MonoBehaviour
{
    private string playerTag = "Player";

    [Header("Cinemachine_READ_ONLY")]
    [SerializeField]
    private CinemachineBrain cinemachineBrain;
    [SerializeField]
    private CinemachineVirtualCamera currentActiveCam;

    [Header("Virtual Cameras GameObjects")]
    [SerializeField]
    private GameObject virtualCam_00;
    private int virtualCam_00_OG_Priority;
    private int virtualCam_00_NEW_Priority;

    [SerializeField]
    private GameObject virtualCam_01;
    private int virtualCam_01_OG_Priority;
    private int virtualCam_01_NEW_Priority;

    [SerializeField]
    private int priorityValueAdditiveAmount = 10;

    private void Start()
    {
        virtualCam_00_OG_Priority = virtualCam_00.GetComponent<CinemachineVirtualCamera>().Priority;
        virtualCam_01_OG_Priority = virtualCam_01.GetComponent<CinemachineVirtualCamera>().Priority;

        cinemachineBrain = CinemachineCore.Instance.GetActiveBrain(0);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentActiveCam = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();

        if (collision.tag == playerTag)
        {
            //If the current cam is Cam_00
            //Upon collide with Trigger -> Trans to Cam_01 
            if(currentActiveCam.name == virtualCam_00.name)
            {
                TransCam_00ToCam_01();
            }

            else
            {
                TransCam_01ToCam_00();
            }
            
        }
    }

    private void TransCam_00ToCam_01()
    {
        //The Maff
        virtualCam_01_NEW_Priority = virtualCam_01_OG_Priority + priorityValueAdditiveAmount;


        //To transition from Cam_00 to Cam_01
        //Cam_01 needs to have higher Prior than Cam_00
        virtualCam_01.GetComponent<CinemachineVirtualCamera>().Priority = virtualCam_01_NEW_Priority;

        //Make sure Cam_00 has OG value
        virtualCam_00.GetComponent<CinemachineVirtualCamera>().Priority = virtualCam_00_OG_Priority;
    }

    private void TransCam_01ToCam_00()
    {
        //The Maff
        virtualCam_00_NEW_Priority = virtualCam_00_OG_Priority + priorityValueAdditiveAmount;


        //To transition from Cam_01 to Cam_00
        //Cam_00 needs to have higher Prior than Cam_01
        virtualCam_00.GetComponent<CinemachineVirtualCamera>().Priority = virtualCam_00_NEW_Priority;

        //Make sure Cam_00 has OG value
        virtualCam_01.GetComponent<CinemachineVirtualCamera>().Priority = virtualCam_01_OG_Priority;
    }
}