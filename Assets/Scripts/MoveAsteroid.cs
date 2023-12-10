using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    public float duration;
    private float currentTime;
    public GameObject beforeTerrain, afterTerrain, impactParticleSystem, tailParticleSystem;

    private void Update()
    {
        currentTime += Time.deltaTime;

        float lerpValue = Mathf.Clamp01(currentTime / duration);
        GetComponent<ModelMatrix>().modelMat[0, 3] = Mathf.Lerp(-36f,434f, lerpValue);
        GetComponent<ModelMatrix>().modelMat[1, 3] = Mathf.Lerp(396, 14, lerpValue);
        GetComponent<ModelMatrix>().modelMat[2, 3] = Mathf.Lerp(700, 188, lerpValue);
        
        //Enables the impact cloud for the asteroid, and disables the tail of the asteroid
        if(currentTime > 4.7)
        {
            impactParticleSystem.SetActive(true);
            tailParticleSystem.SetActive(false);
        }
        //Disables the previous island and enables the new one to make a permanent change to the environment
        if(currentTime > 7)
        {
            beforeTerrain.SetActive(false);
            afterTerrain.SetActive(true);
        }
        
    }
}
