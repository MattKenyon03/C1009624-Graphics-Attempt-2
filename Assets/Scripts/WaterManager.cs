using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    public Waves waves;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        waves = GetComponent<Waves>();
    }

    private void Update()
    {
        //Get the vertices of the object
        Vector3[] vertices = meshFilter.mesh.vertices;

        for(int i = 0; i < vertices.Length; i++)
        {
            //Adjust y-coordinate of each vertex based on the surface 
            vertices[i].y = waves.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        //Update mesh with new values for vertices and recalculate normals
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
