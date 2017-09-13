using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    [RequireComponent(typeof(MeshFilter), typeof(MeshCollider))]
    [ExecuteInEditMode]
    public class BottomPlateMesh : MonoBehaviour
    {

        public int Width = 1;
        public int Height = 1;

        private Mesh _Mesh;

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("COLLISION!!!");
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("TRIGGER!!!");
        }

        public void OnValidate()
        {
            CreateMesh();

            GetComponent<MeshFilter>().mesh = _Mesh;
            GetComponent<MeshCollider>().sharedMesh = _Mesh;
        }

        private void CreateMesh()
        {
            _Mesh = new Mesh();

            _Mesh.vertices = new[]
            {
                new Vector3(0, 0, 0),
                new Vector3(Width, 0, 0),
                new Vector3(0, 0, Height),
                new Vector3(Width, 0, Height)
            };

            _Mesh.triangles = new[]
            {
                0, 2, 1, 2, 3, 1
            };

            //_Mesh.uv = new[]
            //{
            //    new Vector2(0, 0),
            //    new Vector2(1f / Width, 0),
            //    new Vector2(0, 1f / Height),
            //    new Vector2(1f / Width, 1f / Height)
            //};

            _Mesh.uv = new[]
            {
                new Vector2(0, 0),
                new Vector2(Width, 0),
                new Vector2(0, Height),
                new Vector2(Width, Height)
            };
        }
    }
}
