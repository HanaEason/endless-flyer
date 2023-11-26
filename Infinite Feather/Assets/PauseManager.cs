using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public static bool IsPaused = false;
    public AudioManager audioManager;
    private GameObject _pauseMenu;
    
    //get the textmeshpro buttons
    public Button resumeButton;
    public Button quitButton;

    private void Start()
    {
        _pauseMenu = GameObject.Find("PauseMenu");
        _pauseMenu.SetActive(false);
        
        //add the listeners
        resumeButton.onClick.AddListener(TogglePauseGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        if (IsPaused)
        {
            IsPaused = false;
            audioManager.PlayUnpause();
            //hide the pause menu
            _pauseMenu.SetActive(false);
        }
        else
        {
            IsPaused = true;
            audioManager.PlayPause();
            //show the pause menu
            _pauseMenu.SetActive(true);
        }
    }
    
    void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }
    
}
