using System;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{

    private Button quitButton;
    private void Awake()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        quitButton.onClick.RemoveListener(Quit);
    }

    private void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
