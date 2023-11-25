using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public static bool IsPaused = false;
    public AudioManager audioManager;
    private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
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
        if (IsPaused)
        {
            IsPaused = false;
            audioManager.PlayUnpause();
            //hide the pause menu
            pauseMenu.SetActive(false);
        }
        else
        {
            IsPaused = true;
            audioManager.PlayPause();
            //show the pause menu
            pauseMenu.SetActive(true);
        }
    }
    
}
