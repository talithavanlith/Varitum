using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public RectTransform imageTitle;
    public RectTransform buttonPlay, buttonSettings;

    private Vector2 imageTitlePos;
    private bool menuExit;

    void Start()
    {
        imageTitlePos = imageTitle.position;
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    void Update()
    {
        if (menuExit)
        {
            imageTitle.position += new Vector3(0, 5f * Time.deltaTime);
            buttonSettings.position += new Vector3(8f * Time.deltaTime, 0);
            buttonPlay.position -= new Vector3(8f * Time.deltaTime, 0);
        }
        else
            imageTitle.position = new Vector2(0, 0.2f * Mathf.Sin(Time.timeSinceLevelLoad * 1.2f)) + imageTitlePos;  
    }

    public void PlayClicked()
    {
        Debug.Log("PLAY");
        menuExit = true;
        StartCoroutine(DeferExit());
    }

    public void SettingsClicked()
    {
        Debug.Log("SETTINGS");
    }

    IEnumerator DeferExit()
    {
        yield return new WaitForSeconds(2);

        SceneManager.UnloadSceneAsync("MainMenu");
        GameManager.SpawnPlayer();
    }
}
