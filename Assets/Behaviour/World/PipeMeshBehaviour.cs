using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class PipeMeshBehaviour : MonoBehaviour
    {

        public void Start()
        {
            MeshFilter filter = GetComponent<MeshFilter>();

            filter.mesh = new Mesh();

            int width = 500;
            int height = 100;

            CreateVertices(filter.mesh, width, height);
            CreateTriangles(filter.mesh, width);
            CreateUVS(filter.mesh, width, height);
            SetNormals(filter.mesh, width);

            //filter.mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
            //filter.mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
            //filter.mesh.triangles = new int[] { 0, 3, 2, 0, 1, 3 };

            GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Surface");
        }

        private void SetNormals(Mesh m, int width)
        {
            Vector3[] normals = new Vector3[width * 2];
            float degree = 360.0f / width;

            for (int i = 0; i < width; i++)
            {
                //normals[i * 2 + 0] = 
            }

            m.normals = normals;
        }

        private static void CreateVertices(Mesh m, int width, int height)
        {
            Vector3[] vertices = new Vector3[width * 4];

            for (int i = 0; i < width; i++)
            {
                vertices[i * 4 + 0] = new Vector3(i, 0, 0);
                vertices[i * 4 + 1] = new Vector3(i + 1, 0, 0);
                vertices[i * 4 + 2] = new Vector3(i, height, 0);
                vertices[i * 4 + 3] = new Vector3(i + 1, height, 0);
            }

            m.vertices = vertices;
        }

        private static void CreateUVS(Mesh m, int width, int height)
        {
            Vector2[] uvs = new Vector2[width * 4];

            for (int i = 0; i < width; i++)
            {
                uvs[i * 4 + 0] = new Vector2(0, 0);
                uvs[i * 4 + 1] = new Vector2(1, 0);
                uvs[i * 4 + 2] = new Vector2(0, height);
                uvs[i * 4 + 3] = new Vector2(1, height);
            }

            m.uv = uvs;
        }

        private static void CreateTriangles(Mesh m, int width)
        {
            int[] trianges = new int[6 * width];

            for (int i = 0; i < width; i++)
            {
                trianges[i * 6 + 0] = i * 4 + 0;
                trianges[i * 6 + 1] = i * 4 + 3;
                trianges[i * 6 + 2] = i * 4 + 2;
                trianges[i * 6 + 3] = i * 4 + 0;
                trianges[i * 6 + 4] = i * 4 + 1;
                trianges[i * 6 + 5] = i * 4 + 3;
            }

            m.triangles = trianges;
        }

        public void Update()
        {

        }
    }
}