using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    public class EllipticalPlane : MonoBehaviour
    {

        public int Triangles = 10;
        public float Radius = 0.5f;

        private Mesh _Mesh;

        public void OnValidate()
        {
            if (_Mesh == null)
            {
                _Mesh = new Mesh();
            }

            SetupMesh();
        }

        private void SetupMesh()
        {
            float step = 360.0f / Triangles;

            Quaternion rotation = Quaternion.Euler(0, 0, step);

            Vector3[] vertices = new Vector3[Triangles + 1];
            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = new Vector3(0, Radius, 0);

            int[] triangles = new int[3 * Triangles];
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;

            Vector2[] uvs = new Vector2[Triangles + 1];
            uvs[0] = new Vector2(0.5f + (vertices[0].x) / (2 * Radius), 0.5f + (vertices[0].y) / (2 * Radius));
            uvs[1] = new Vector2(0.5f + (vertices[1].x) / (2 * Radius), 0.5f + (vertices[1].y) / (2 * Radius));

            for (int i = 1; i < Triangles; i++)
            {
                vertices[i + 1] = rotation * vertices[i];

                triangles[3 * i + 0] = 0;
                triangles[3 * i + 1] = i + 1;
                triangles[3 * i + 2] = i + 1 == Triangles ? 1 : i + 2;

                uvs[i + 1] = new Vector2(0.5f + (vertices[i + 1].x) / (2 * Radius), 0.5f + (vertices[i + 1].y) / (2 * Radius));
            }

            _Mesh.vertices = vertices;
            _Mesh.triangles = triangles;
            _Mesh.uv = uvs;

            GetComponent<MeshFilter>().mesh = _Mesh;
            GetComponent<MeshCollider>().sharedMesh = _Mesh;
        }
    }
}
