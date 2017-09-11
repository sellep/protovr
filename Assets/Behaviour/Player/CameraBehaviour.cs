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

        public void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            Yaw += SpeedH * Input.GetAxis("Mouse X");
            Pitch -= SpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(Pitch, Yaw, 0.0f);
        }
    }
}
