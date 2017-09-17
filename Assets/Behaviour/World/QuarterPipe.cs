using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class QuarterPipe : MonoBehaviour
{

    public float Radius = 1;
    public int Points = 5;
    public float Length = 10;

    private Mesh _Mesh;

    private void OnValidate()
    {
        if (Points < 2)
            return;

        float angle = 90.0f / (Points - 1);

        Vector3[] vertices = new Vector3[2 * Points];
        vertices[0] = new Vector3(0, -Radius, 0);
        vertices[Points] = new Vector3(0, -Radius, Length);

        int[] triangles = new int[6 * (Points - 1)];

        for (int i = 1; i < Points; i++)
        {
            vertices[i] = Quaternion.AngleAxis(angle, Vector3.forward) * vertices[i - 1];
            vertices[Points + i] = Quaternion.AngleAxis(angle, Vector3.forward) * vertices[Points + i - 1];

            triangles[(i - 1) * 3 + 0] = i;
            triangles[(i - 1) * 3 + 1] = i - 1;
            triangles[(i - 1) * 3 + 2] = Points + i - 1;

            triangles[(Points + i - 2) * 3 + 0] = Points + i - 1;
            triangles[(Points + i - 2) * 3 + 1] = Points + i;
            triangles[(Points + i - 2) * 3 + 2] = i;
        }

        _Mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles
        };

        GetComponent<MeshFilter>().mesh = _Mesh;
    }
}
