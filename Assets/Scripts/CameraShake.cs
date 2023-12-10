using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeAmount ;
    public static bool isShaking;
    private float shakeStartTime;

    void Start()
    {
        //Initialises the shake amount
        shakeAmount = 0f;

       //Sets start time to 5 seconds, as the shake starts 5 seconds into the scene
       shakeStartTime = 5;
    }

    void FixedUpdate()
    {
        // Checks if the shake effect is active
        if (isShaking)
        {
            // Calculate the elapsed time since the shake started (from 5 seconds)
            float elapsed = Time.time - shakeStartTime;
            
            // Check if the shake duration has elapsed
            if (elapsed < shakeDuration)
            {
                //Builds up from small shake amount to large shake amount before eruption
                if(elapsed < 5)
                {
                    shakeAmount = elapsed * 0.3f;
                }
                //Reduces shake amount after eruption
                else
                {
                    shakeAmount = (elapsed * -0.15f) + 2.25f;
                }
                
                // Generate a random offset based on the shakeAmount
                Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;

                //Add the offset to the current position of the camera
                transform.position += randomOffset;
            }
        }
    }
}

