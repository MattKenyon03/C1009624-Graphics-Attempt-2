using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexShader : MonoBehaviour
{
    private void Update()
    {
        //Activates the vertex shader
        MeshRenderer m = GetComponent<MeshRenderer>();
        m.material.SetFloat("movement", Time.realtimeSinceStartup);
    }
}
