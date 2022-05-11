using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransButton : MonoBehaviour
{
    [SerializeField]
    private string sceneName_READ_ONLY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }

    public void ExitGameButton()
    {
        Debug.Log("Exit successfully");
        Application.Quit();
    }
}
