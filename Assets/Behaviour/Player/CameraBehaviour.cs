using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.Player
{

    public class CameraBehaviour : MonoBehaviour
    {

        public float SpeedH = 2.0f;
        public float SpeedV = 2.0f;

        private float Yaw = 0.0f;
        private float Pitch = 0.0f;

        private Transform _Head;

        public void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            _Head = transform.Find("Head");
        }

        public void Update()
        {
            Yaw = SpeedH * Input.GetAxis("Mouse X");
            Pitch = SpeedV * Input.GetAxis("Mouse Y") * -1;

            transform.eulerAngles += new Vector3(0, Yaw, 0.0f);
            _Head.localEulerAngles += new Vector3(Pitch, 0, 0.0f);
        }
    }
}
