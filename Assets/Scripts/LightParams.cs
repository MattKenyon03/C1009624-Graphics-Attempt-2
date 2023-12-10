using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParams : MonoBehaviour
{
    [SerializeField]
    Light worldLight;

    [SerializeField]
    GameObject cameraObject;

    [SerializeField]
    float specularPower = 10.0f;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer r = GetComponent<MeshRenderer>();

        r.material.SetVector("camPosition", cameraObject.transform.position);

        r.material.SetVector("lightPosition", worldLight.transform.position);
        r.material.SetColor("lightColour", worldLight.color);

        r.material.SetFloat("lightIntensity", worldLight.intensity);
        r.material.SetFloat("lightRange", worldLight.range);

        r.material.SetFloat("specularPower", specularPower);
    }
}
