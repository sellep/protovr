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


        public float gravity = 20.0F;
        public float rotate = 360; // rotate speed in degrees/second
        private Vector3 moveDirection = Vector3.zero;
        public CharacterController Character;

        public void Awake()
        {
            Character = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (Character.isGrounded)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Debug.Log("running");
                    moveDirection *= SpeedRunning;
                }
                else
                {
                    moveDirection *= SpeedNormal;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = JumpSpeed;
                }

                transform.Rotate(0, Input.GetAxis("Horizontal") * rotate * Time.deltaTime, 0);
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y += JumpSpeed;
                }
            }

            moveDirection.y -= gravity * Time.deltaTime;
            Character.Move(moveDirection * Time.deltaTime);
        }
    }
}
