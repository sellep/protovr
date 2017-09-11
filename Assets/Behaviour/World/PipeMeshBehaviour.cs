using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    public class PipeMeshBehaviour : MonoBehaviour
    {

        public int Width = 100;
        public int Height = 100;

        private Mesh _Mesh;

        public void Awake()
        {
            _Mesh = new Mesh();

            CreateVertices(_Mesh, Width, Height);
            CreateTriangles(_Mesh, Width);
            CreateUVS(_Mesh, Width, Height);
        }

        public void Start()
        {
            GetComponent<MeshFilter>().mesh = _Mesh;
            GetComponent<MeshCollider>().sharedMesh = _Mesh;


            transform.localPosition += new Vector3(0, 0, Width / (2 * Mathf.PI));
        }

        private static void CreateVertices(Mesh m, int width, int height)
        {
            Vector3[] vertices = new Vector3[width * 4];
            float degree = 360.0f / width;

            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = Quaternion.AngleAxis(degree, Vector3.up) * new Vector3(1, 0, 0);
            vertices[2] = new Vector3(0, height, 0);
            vertices[3] = Quaternion.AngleAxis(degree, Vector3.up) * new Vector3(1, height, 0);

            for (int i = 1; i < width; i++)
            {
                vertices[i * 4 + 0] = vertices[(i - 1) * 4 + 1];
                vertices[i * 4 + 2] = vertices[(i - 1) * 4 + 3];

                Vector3 newv = vertices[i * 4 + 0];
                newv.x++;
                vertices[i * 4 + 1] = Quaternion.AngleAxis(degree, Vector3.up) * newv;


                newv = vertices[i * 4 + 2];
                newv.x++;
                vertices[i * 4 + 3] = Quaternion.AngleAxis(degree, Vector3.up) * newv;
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