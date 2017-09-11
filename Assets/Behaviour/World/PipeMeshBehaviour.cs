using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    public class PipeMeshBehaviour : MonoBehaviour
    {

        public void Start()
        {
            Mesh mesh = new Mesh();

            CreateVertices(mesh, 100, 2);
            CreateTriangles(mesh, 100);

            //mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
            mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
            //mesh.triangles = new int[] { 0, 2, 3, 0, 3, 1 };

            gameObject.AddComponent<MeshRenderer>();
            GetComponent<MeshFilter>().mesh = mesh;


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

        private static void CreateTriangles(Mesh m, int width)
        {
            int[] trianges = new int[6 * width];

            for (int i = 0; i < width; i++)
            {
                trianges[i * 6 + 0] = i * 4 + 0;
                trianges[i * 6 + 1] = i * 4 + 2;
                trianges[i * 6 + 2] = i * 4 + 3;
                trianges[i * 6 + 3] = i * 4 + 0;
                trianges[i * 6 + 4] = i * 4 + 3;
                trianges[i * 6 + 5] = i * 4 + 1;
            }

            m.triangles = trianges;
        }

        public void Update()
        {

        }
    }
}