using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stylized_Astronaut.Character;

public class PortalScript : MonoBehaviour
{
    
    public AstronautPlayer astronautPlayer;
    public PauseManager pauseManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Get the location of the astronautPlayer
        var playerPosition = astronautPlayer.GetPosition();
        
        //Get the location of the portal
        var portalPosition = transform.position;
        
        //Get the distance between the player and the portal
        var distance = Vector3.Distance(playerPosition, portalPosition);
        
        //print the distance
        print(distance.ToString());
        
        //if the player is near the portal
        if (distance <= 5.0f)
        {
            //pause the game
            pauseManager.ShowEndScreen();
        }
        
    }
}
