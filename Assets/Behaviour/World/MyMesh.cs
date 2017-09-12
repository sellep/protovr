using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{
    public class MyMesh : MonoBehaviour
    {

        private Mesh _Mesh;

        public void Start()
        {
            _Mesh = new Mesh();
            _Mesh.name = "Pipe Mesh";

            

            _Mesh.vertices = new[]
            {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(0,1,0),
                new Vector3(1,1,0)
            };

            _Mesh.triangles = new[] { 0, 2, 1, 2, 3, 1 };

            _Mesh.normals = new[]
            {
                Vector3.forward,
                Vector3.forward,
                Vector3.forward,
                Vector3.forward
            };

            _Mesh.uv = new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            GetComponent<MeshFilter>().mesh = _Mesh;
            GetComponent<MeshCollider>().sharedMesh = _Mesh;

            _Mesh.RecalculateNormals();
        }
    }
}
