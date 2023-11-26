using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public static bool IsPaused = false;
    public AudioManager audioManager;
    private GameObject _pauseMenu;

    private void Start()
    {
        _pauseMenu = GameObject.Find("PauseMenu");
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        //print debug message
        print("PAUSED");
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
        Application.Quit();
    }
    
}
