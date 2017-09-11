using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.Player
{

    public class MovementBehaviour : MonoBehaviour
    {
        public float SpeedNormal = 6.0f;
        public float SpeedRunning = 24.0f;

        public float JumpSpeed = 64.0f;
        public bool IsJump;

        /*
         * Rotation speed in degrees/second
         */
        public float RotationSpeed = 360;
        public float AirRotationSpeed = 120;


        public float gravity = 20.0F;
        private CharacterController _Character;

        public Vector3 MoveDirection = Vector3.zero;

        public void Awake()
        {
            _Character = GetComponent<CharacterController>();
        }

        

        void Update()
        {
            if (_Character.isGrounded)
            {
                IsJump = false;

                MoveDirection = transform.TransformDirection(new Vector3(0, 0, Input.GetAxis("Vertical")));

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    MoveDirection *= SpeedRunning;
                }
                else
                {
                    MoveDirection *= SpeedNormal;
                }

                if (Input.GetButton("Jump"))
                {
                    MoveDirection.y = JumpSpeed;
                    IsJump = true;
                }

                transform.Rotate(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0);
            }
            else if (IsJump)
            {
                MoveDirection = Quaternion.Euler(0, Input.GetAxis("Horizontal"), 0) * MoveDirection;
            }

            MoveDirection.y -= gravity * Time.deltaTime;
            _Character.Move(MoveDirection * Time.deltaTime);
        }
    }
}
