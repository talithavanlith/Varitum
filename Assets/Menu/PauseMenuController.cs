using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public Canvas canvasPause, canvasSettings;

    void Start()
    {
        canvasPause.enabled = false;
        canvasSettings.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    private void TogglePause()
    {
        canvasPause.enabled = !canvasPause.enabled;
        Time.timeScale = canvasPause.enabled ? 0 : 1;
    }

    public void ContinueClicked()
    {
        TogglePause();
    }

    public void SettingsClicked()
    {
        Debug.Log("SETTINGS");
    }

    public void QuitClicked()
    {
        Debug.Log("QUIT");
    }
}
