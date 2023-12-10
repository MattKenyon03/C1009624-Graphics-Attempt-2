using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Profiling;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI framerateText, reservedMemoryText, allocatedMemoryText;

    int frameCounter = 0;
    float timeCounter = 0.0f;
    float lastFramerate = 0.0f;
    public float refreshTime, allocatedMemoryMB;

    void Update()
    {
        if (timeCounter < refreshTime)
        {
            //Calculates the time between updates and keeps track of frames passed
            timeCounter += Time.deltaTime;
            frameCounter++;
        }
        else
        {
            //Calculates the average framerate over this time
            lastFramerate = (float)frameCounter / timeCounter;

            //Sets counter and time back to 0 for next update
            frameCounter = 0;
            timeCounter = 0.0f;

            //Uses unity's profiler to calculate amount of memory being used
            long allocatedMemory = Profiler.GetTotalAllocatedMemoryLong();

            //Converts the memory from bytes to Megabytes
            allocatedMemoryMB = (allocatedMemory / (1024f * 1024f));
        }

        //Outputs both values as text 
        framerateText.text = lastFramerate.ToString();
        allocatedMemoryText.text = allocatedMemoryMB + "MB";
    }
}
