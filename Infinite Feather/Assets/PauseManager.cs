using Stylized_Astronaut.Character;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public static bool IsPaused = false;
    public AudioManager audioManager;
    public AstronautPlayer astronautPlayer;
    private GameObject _pauseMenu;
    private GameObject _endScreen;
    
    //get the textmeshpro buttons
    public Button resumeButton;
    public Button quitButton;
    
    //get the sliders
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider gravitySlider;

    private void Start()
    {
        _pauseMenu = GameObject.Find("PauseMenu");
        _pauseMenu.SetActive(false);
        _endScreen = GameObject.Find("EndScreen");
        _endScreen.SetActive(false);
        
        //add the listeners
        resumeButton.onClick.AddListener(TogglePauseGame);
        quitButton.onClick.AddListener(QuitGame);
        
        //add the listeners
        soundSlider.onValueChanged.AddListener(audioManager.SetSoundVolume);
        musicSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);
        gravitySlider.onValueChanged.AddListener(astronautPlayer.SetGravity);
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
        }
        else
        {
            IsPaused = true;
            audioManager.PlayPause();
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
            //show the pause menu
            _pauseMenu.SetActive(true);
        }
    }
    
    public void ShowEndScreen()
    {
        IsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _endScreen.SetActive(true);
    }
    
    void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }
    
}
