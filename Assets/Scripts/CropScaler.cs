using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropScaler : MonoBehaviour
{
    public float duration;
    private float currentTime;
    private float maxGrowth;

    private void Start()
    {
        //Generates random maximum scale for the crops to grow to
        maxGrowth = Random.Range(0.8f, 1.2f);
    }

    private void Update()
    {
        //Calculates current time
        currentTime += Time.deltaTime;

        //Uses lerp to slowly change the scale of the crops from 0 to their maximum
        float lerpValue = Mathf.Clamp01(currentTime / duration);
        GetComponent<ModelMatrix>().modelMat[0, 0] = Mathf.Lerp(0, maxGrowth, lerpValue);
        GetComponent<ModelMatrix>().modelMat[1, 1] = Mathf.Lerp(0, maxGrowth, lerpValue);
        GetComponent<ModelMatrix>().modelMat[2, 2] = Mathf.Lerp(0, maxGrowth, lerpValue);
    }
}
