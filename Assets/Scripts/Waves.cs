using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public Waves instance;
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        //Changes offset overtime depending on speed
        offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
        //Calculate the wave height with sin
        return amplitude * Mathf.Sin(x / length + offset);
    }

}
