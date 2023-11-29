using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Light sun;
    [SerializeField, Range(0,24)] private float time;

    [SerializeField] private float rotationSpeed;
    
    //[SerializeField] private Gradient skyColor;
    //[SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;

    private void UpdateRotation(){
        float theta = time/24.0f;
        float sunRotation = Mathf.Lerp(-90,270,theta);
        sun.transform.rotation = Quaternion.Euler(sunRotation, -92.0f, 0);
        
    }

    private void UpdateLighting(){
        float timeComponent = time/24.0f;
        //RenderSettings.ambientEquatorColor = equatorColor.Evaluate(timeComponent);
        //RenderSettings.ambientSkyColor = skyColor.Evaluate(timeComponent);
        sun.color = sunColor.Evaluate(timeComponent);
    }
   
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * rotationSpeed;
        if(time>24){
            time=0;
        }

        UpdateRotation();
        UpdateLighting();
    }

    
    private void onValidate(){
        UpdateRotation();
        UpdateLighting();
    }

}
