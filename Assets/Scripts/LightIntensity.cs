using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{

    public Light lightIntensity;

    private void Update()
    {
        //Checks if the sun is under a certain y value, and disables the light so that it doesn't interfere with the scene
        if(transform.position.y < -300)
        {
            lightIntensity.intensity = 0;
        }
        else
        {
            lightIntensity.intensity = 4;
        }
    }
}
