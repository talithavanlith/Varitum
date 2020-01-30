using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    // Reference to panel's script object 
    PauseMenuManager pauseMenu;

    // Use this for initialization
    void Start()
    {

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    // Update is called once per frame
    void Update()
    {

    if (Input.GetKey(KeyCode.Escape))
        {
            // If user presses ESC, show the pause menu in pause mode
            pauseMenu.ShowPause();
        }
    }
}