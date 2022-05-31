using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Cinemachine;

public class CameraTransitionBehaviour : MonoBehaviour
{
    private string playerTag = "Player";

    [Header("Cinemachine_READ_ONLY")]
    [SerializeField]
    private CinemachineBrain cinemachineBrain;
    [SerializeField]
    private CinemachineVirtualCamera currentActiveCam;

    [Header("Virtual Cameras GameObjects")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCam_00;
    [SerializeField]
    private int virtualCam_00_OG_Priority;
    [SerializeField]
    private int virtualCam_00_NEW_Priority;

    [SerializeField]
    private CinemachineVirtualCamera virtualCam_01;
    [SerializeField]
    private int virtualCam_01_OG_Priority;
    [SerializeField]
    private int virtualCam_01_NEW_Priority;

    [SerializeField]
    private int priorityValueAdditiveAmount = 10;

    [Header("CameraEvent")]
    [SerializeField]
    private int cameraID;

    private void Start()
    {
        virtualCam_00_OG_Priority = virtualCam_00.Priority;
        virtualCam_01_OG_Priority = virtualCam_01.Priority;

        cinemachineBrain = CinemachineCore.Instance.GetActiveBrain(0);
        //UpdateActivatedCamera();
    }

    private void OnEnable()
    {
        CameraEventManager.onVCameraTransitioned += ActivateCameraTransition;
        CameraEventManager.onNPC_1CameraPos += StartWithCam_01;
    }

    private void OnDisable()
    {
        CameraEventManager.onVCameraTransitioned -= ActivateCameraTransition;
        CameraEventManager.onNPC_1CameraPos -= StartWithCam_01;
    }

    private void ActivateCameraTransition(int cameraID)
    {
        if (this.cameraID == cameraID)
        {
            currentActiveCam = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            //UpdateActivatedCamera();

            Debug.Log("Call upon CamTrans");
            //If the current cam is Cam_00
            //Upon collide with Trigger -> Trans to Cam_01 
            if (currentActiveCam.name == virtualCam_00.name)
            {
                TransCam_00ToCam_01();
            }

            else
            {
                TransCam_01ToCam_00();
            }
        }

    }

    private void UpdateActivatedCamera()
    {
        currentActiveCam = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
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

    //This Method is public so I can access from SpawnerMaster.VCamPosAtSpawn()
    //But only with UnityEvent
    //public void TransCam_01ToCam_00()
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

    //This is a special method to subscribe to the special case of SpawnerMaster (the special Handler)
    //Basically instead of starting Scene from Cam_01 (the below), we start from Cam_00 (above)
    private void StartWithCam_01()
    {
        //By have it start with Cam_01 -> Start off with higher Priority
        //only half of the AdditiveValue to avoid conflicts later

        virtualCam_01.Priority += priorityValueAdditiveAmount / 2;
        Debug.Log("Starting with Cam_00");
    }
}