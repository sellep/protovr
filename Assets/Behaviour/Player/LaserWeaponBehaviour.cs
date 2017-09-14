using Assets.Behaviour.World;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.Player
{

    public class LaserWeaponBehaviour : MonoBehaviour
    {
        public const float FACTOR_DISCHARGE = 0.15f;
        public const float FACTOR_CHARGE = 0.25f;
        public const int MAX_BEAM_DISTANCE = 500;

        public Transform LeftHand;
        public Transform RightHand;

        public LineRenderer LeftBeam;
        public LineRenderer RightBeam;

        public float LeftCharge = 1f;
        public float RightCharge = 1f;

        private Vector2 _ScreenMiddle;

        public void Awake()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Player/Beam");

            LeftBeam = Instantiate(prefab, transform).GetComponent<LineRenderer>();
            RightBeam = Instantiate(prefab, transform).GetComponent<LineRenderer>();

            LeftHand = transform.Find("LeftHand");
            RightHand = transform.Find("RightHand");

            _ScreenMiddle = new Vector2(Screen.width * .5f, Screen.height * .5f);
        }

        public void Start()
        {
            LeftBeam.enabled = false;
            RightBeam.enabled = false;
        }

        public void Update()
        {
            HandleWeapon(0, LeftHand, LeftBeam, ref LeftCharge);
            HandleWeapon(1, RightHand, RightBeam, ref RightCharge);
        }

        private void HandleWeapon(int button, Transform hand, LineRenderer beam, ref float charge)
        {
            if (Input.GetMouseButtonDown(button))
            {
                beam.enabled = true;

                ApplyRay(hand, beam);
            }
            else if (Input.GetMouseButton(button))
            {
                if (charge > 0)
                {
                    charge -= Time.deltaTime * FACTOR_DISCHARGE;
                    ApplyRay(hand, beam);
                }
                else
                {
                    beam.enabled = false;
                }
            }
            else if (Input.GetMouseButtonUp(button))
            {
                beam.enabled = false;
            }
            else if (LeftCharge < 1)
            {
                charge += Time.deltaTime * FACTOR_CHARGE;
            }
        }

        private void ApplyRay(Transform hand, LineRenderer beam)
        {
            Ray ray = Camera.main.ScreenPointToRay(_ScreenMiddle);
            RaycastHit hit;

            beam.SetPosition(0, hand.position);

            if (Physics.Raycast(ray, out hit))
            {
                beam.SetPosition(1, hit.point);

                if (hit.transform.gameObject.tag == "Target")
                {
                    Destroy(hit.transform.gameObject);
                }

                //if (hit.transform.gameObject.tag == "Target")
                //{
                //    GameObject.Find("Target Spawn Area").GetComponent<SpawnableAreaBehaviour>().OnTargetHit(hit.transform.gameObject);
                //}
            }
            else
            {
                beam.SetPosition(1, ray.GetPoint(MAX_BEAM_DISTANCE));
            }
        }
    }
}
