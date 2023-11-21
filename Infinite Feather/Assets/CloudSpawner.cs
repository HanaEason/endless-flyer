using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    class CloudData
    {
        public Vector3 initialPosition;
        public float travelDistance;
        public bool respawning = false;
        
        public CloudData(Vector3 initialPosition, float travelDistance)
        {
            this.initialPosition = initialPosition;
            
            //Take the travel distance and add some randomization to it
            this.travelDistance = travelDistance + Random.Range(-travelDistance * 0.2f, travelDistance * 0.2f); //20% randomization
        }
    }

    public float movementSpeed = 2.0f;
    public float travelDistance = 250.0f;
    private Dictionary<Transform, CloudData> _clouds = new Dictionary<Transform, CloudData>();

    // Start is called before the first frame update
    void Start()
    {
        //get all of the clouds and store their initial positions
        foreach (var child in transform)
        {
            Transform childTransform = (Transform)child;
            _clouds.Add(childTransform, new CloudData(childTransform.position, travelDistance));
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<Transform,CloudData> cloud in _clouds)
        {
            
            //Check to see if the cloud has reached the end of its travel distance
            if (Vector3.Distance(cloud.Key.position, cloud.Value.initialPosition) > cloud.Value.travelDistance && !cloud.Value.respawning)
            {
                //start the coroutine to fade out, move, and fade back in
                StartCoroutine(RespawnCloud(cloud.Key, cloud.Value, cloud.Value.initialPosition));
            }
            else
            {
                //move the cloud along
                cloud.Key.position += Vector3.forward * (movementSpeed * Time.deltaTime);
            }
            
        }
    }
    
    //coroutine that will fade out, change cloud position, and fade back in
    IEnumerator RespawnCloud(Transform cloud, CloudData cloudData, Vector3 newPosition)
    {
        cloudData.respawning = true;
        Color cloudColor = cloud.GetComponent<Renderer>().material.color;
        float fadeTime = 10f;
        float fadeSpeed = 1.0f / fadeTime;
        float fade = 0.0f;
        while (fade < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            cloud.GetComponent<Renderer>().material.color = new Color(cloudColor.r, cloudColor.g, cloudColor.b, Mathf.Lerp(1, 0, fade));
            yield return null;
        }
        
        cloud.position = newPosition; //reset the cloud position
        
        fade = 0.0f;
        while (fade < 1.0f)
        {
            fade += Time.deltaTime * fadeSpeed;
            cloud.GetComponent<Renderer>().material.color = new Color(cloudColor.r, cloudColor.g, cloudColor.b, Mathf.Lerp(0, 1, fade));
            yield return null;
        }

        cloudData.respawning = false;
    }
    
}
