using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMatrix : MonoBehaviour
{ 
    [SerializeField]
    public Matrix4x4 modelMat = Matrix4x4.identity;

    [SerializeField]
    bool writeValues;

    // Update is called once per frame
    void Update()
    {
        if (writeValues)
        {
            //Changes the matrix to a transform for the editor
            transform.localPosition = MatrixFunctions.ExtractTranslationFromMatrix(ref modelMat);
            transform.localScale = MatrixFunctions.ExtractScaleFromMatrix(ref modelMat);
            transform.localRotation = MatrixFunctions.ExtractRotationFromMatrix(ref modelMat);
        }
        else
        {
            //Loads the matrix values from the transform
            modelMat = transform.localToWorldMatrix;
        }
    }
}
