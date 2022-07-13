using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class Inventory_ResetPosOnSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.activeSceneChanged += ResetPosition;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= ResetPosition;
    }

    private void ResetPosition(Scene currentScene , Scene nextScene)
    {
        this.gameObject.transform.position = Vector3.zero;
        //Debug.Log("Inventory Pos has been reset due to scene change");
    }
}