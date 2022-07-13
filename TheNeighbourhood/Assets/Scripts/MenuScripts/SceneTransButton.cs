using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransButton: MonoBehaviour
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
        StartCoroutine(SmallDelayForSFX(sceneIndex));
    }

    public void ExitGameButton()
    {
        Debug.Log("Exit successfully");
        Application.Quit();
    }

    IEnumerator SmallDelayForSFX(int sceneIndex)
    {
        yield return new WaitForSeconds(0.2f);
        //Debug.Log("Finish Delay");
        SceneManager.LoadScene(sceneIndex);
    }
}
