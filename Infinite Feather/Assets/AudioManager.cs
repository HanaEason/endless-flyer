using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private AudioSource _soundEffectSource;
    public AudioSource backgroundMusicSource;
    
    public AudioClip[] audioClips;
    public AudioClip backgroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        _soundEffectSource = GetComponent<AudioSource>();
        
        //set the default volumes for the audio
        SetSoundVolume(PlayerPrefs.GetFloat("SoundVolume", 1f));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        
        //play the background music
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }
    
    public void SetSoundVolume(float volume)
    {
        _soundEffectSource.volume = volume;
        //save the volume to player prefs so it persists between sessions
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
        //save the volume to player prefs so it persists between sessions
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    
    public void PlayCamSwitch()
    {
        _soundEffectSource.PlayOneShot(audioClips[0]);
    }

    public void PlayPause()
    {
        _soundEffectSource.PlayOneShot(audioClips[1]);
    }

    public void PlayUnpause()
    {
        _soundEffectSource.PlayOneShot(audioClips[2]);
    }
    
}
