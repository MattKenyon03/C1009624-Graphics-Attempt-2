using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float duration;
    private float currentTime;
    private ModelMatrix matrix;

    private void Start()
    {
        matrix = GetComponent<ModelMatrix>();
    }

    private void Update()
    {
        //Increases ship's y value over time until it reaches y=150
        currentTime += Time.deltaTime;
        float lerpValue = Mathf.Clamp01(currentTime / duration);
        matrix.modelMat[1, 3] = Mathf.Lerp(44f, 150f, lerpValue);
    }
}
