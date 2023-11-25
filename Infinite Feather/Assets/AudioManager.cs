using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayCamSwitch()
    {
        _audioSource.PlayOneShot(audioClips[0]);
    }

    public void PlayPause()
    {
        _audioSource.PlayOneShot(audioClips[1]);
    }

    public void PlayUnpause()
    {
        _audioSource.PlayOneShot(audioClips[2]);
    }
    
}
