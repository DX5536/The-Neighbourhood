using UnityEngine;
using UnityEngine.UI;

public class Button_PlayButtonSFX: MonoBehaviour
{
    [Header("Auto assign READ_ONLY")]
    [SerializeField]
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SoundManager.instance.PlayButtonSFX);
    }

    public void OnHoverButton()
    {
        SoundManager soundManager = SoundManager.instance;
        soundManager.PlayHoverButtonSFX();
    }
}