using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.Player
{

    public class MovementBehaviour : MonoBehaviour
    {
        public const float GRAVITY_FORCE = 20.0F;
        public float SpeedNormal = 6.0f;
        public float SpeedRunning = 24.0f;
        public float AirFactor = 0.2f;

        public float JumpSpeed = 24.0f;
        public bool IsJump;


        private CharacterController _Character;

        public Vector3 MoveDirection = Vector3.zero;

        public void Awake()
        {
            _Character = GetComponent<CharacterController>();
        }

        public void Update()
        {
            if (_Character.isGrounded)
            {
                IsJump = false;

                MoveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

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

                //transform.Rotate(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0);
            }
            else if (IsJump)
            {
                MoveDirection += AirFactor * transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            }

            MoveDirection.y -= GRAVITY_FORCE * Time.deltaTime;
            _Character.Move(MoveDirection * Time.deltaTime);
        }
    }
}
