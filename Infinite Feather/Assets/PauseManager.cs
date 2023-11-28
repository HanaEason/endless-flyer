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
    
    //get the sliders
    public Slider soundSlider;
    public Slider musicSlider;

    private void Start()
    {
        _pauseMenu = GameObject.Find("PauseMenu");
        _pauseMenu.SetActive(false);
        
        //add the listeners
        resumeButton.onClick.AddListener(TogglePauseGame);
        quitButton.onClick.AddListener(QuitGame);
        
        //add the listeners
        soundSlider.onValueChanged.AddListener(audioManager.SetSoundVolume);
        musicSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);
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

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            //hide the pause menu
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            IsPaused = true;
            audioManager.PlayPause();
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
            //show the pause menu
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }
    
}
