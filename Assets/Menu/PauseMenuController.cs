using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Canvas canvasPause, canvasSettings;
    public Toggle toggleSound, toggleMusic;

    private Color toggleColor = new Color(0.240566f, 0.817987f, 1.0f);

    void Start()
    {
        canvasPause.enabled = false;
        canvasSettings.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.inPlay)
            SetPaused(!canvasPause.enabled);
    }

    private void SetPaused(bool paused)
    {
        canvasPause.enabled = paused;
        canvasSettings.enabled = false;
        Time.timeScale = paused ? 0 : 1;
    }

    public void ContinueClicked()
    {
        SetPaused(false);
    }

    public void SettingsClicked()
    {
        canvasPause.enabled = false;

        toggleSound.isOn = GameManager.soundEnabled;
        toggleSound.GetComponentInChildren<Image>().color = GameManager.soundEnabled ? toggleColor : Color.white;
        toggleMusic.isOn = GameManager.musicEnabled;
        toggleMusic.GetComponentInChildren<Image>().color = GameManager.musicEnabled ? toggleColor : Color.white;

        canvasSettings.enabled = true;
    }

    public void SettingsBackClicked()
    {
        SetPaused(true);
    }


    public void SettingsToggleSoundChanged()
    {
        GameManager.soundEnabled = !GameManager.soundEnabled;
        toggleSound.GetComponentInChildren<Image>().color = GameManager.soundEnabled ? toggleColor : Color.white;
    }

    public void SettingsToggleMusicChanged()
    {
        GameManager.musicEnabled = !GameManager.musicEnabled;
        toggleMusic.GetComponentInChildren<Image>().color = GameManager.musicEnabled ? toggleColor : Color.white;
    }

    public void QuitClicked()
    {
        Debug.Log("QUIT");
    }


}
