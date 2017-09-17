using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    [RequireComponent(typeof(MeshFilter), typeof(MeshCollider), typeof(Rigidbody))]
    [ExecuteInEditMode]
    public class BottomPlateMesh : MonoBehaviour
    {

        public int Width = 1;
        public int Height = 1;

        private Mesh _Mesh;
        private Rigidbody _Ridig;

        public void OnValidate()
        {
            CreateMesh();

            GetComponent<MeshFilter>().mesh = _Mesh;
            GetComponent<MeshCollider>().sharedMesh = _Mesh;
            _Ridig = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            Debug.Log(_Ridig.centerOfMass);
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
