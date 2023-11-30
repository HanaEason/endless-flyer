using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour, IInteractable
{
    public AudioSource musicSource;
    public AudioClip animalSound;
    
    public void Interact() {
        Debug.Log("INTERACTED!!");
        //play the music
        musicSource.clip = animalSound;
        musicSource.loop = false;
        musicSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}