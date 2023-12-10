using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    public float amplitude = 1f;
    public float startTime;
    public bool rotateY;

    void Awake()
    {
        startTime = Time.time;
    }

    void Update()
    {

        //Calculates the value of sin and cos over time
        float sinVal = amplitude * Mathf.Sin(speed * (Time.time - startTime));
        float cosVal = amplitude * Mathf.Cos(speed * (Time.time - startTime));

        //Accelerates the speed of the ship orbit until it reaches its maximum
        if(name == "Ship Rotation Orbit")
        {
            if(Time.time - startTime < 10)
            {
                speed = 0.01f * (Time.time - startTime);
            }
            
        }

        //Rotates object in the y axis
        if(rotateY)
        {
            GetComponent<ModelMatrix>().modelMat[0, 0] = cosVal;
            GetComponent<ModelMatrix>().modelMat[0, 2] = sinVal;
            GetComponent<ModelMatrix>().modelMat[2, 0] = -sinVal;
            GetComponent<ModelMatrix>().modelMat[2, 2] = cosVal;
        }
        //Rotates object in the x axis
        else
        {
            GetComponent<ModelMatrix>().modelMat[1, 1] = cosVal;
            GetComponent<ModelMatrix>().modelMat[1, 2] = -sinVal;
            GetComponent<ModelMatrix>().modelMat[2, 1] = sinVal;
            GetComponent<ModelMatrix>().modelMat[2, 2] = cosVal;
        }
        
    }
}
