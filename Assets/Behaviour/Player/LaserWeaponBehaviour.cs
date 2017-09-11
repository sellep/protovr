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
        public Transform LeftHand;
        public Transform RightHand;

        public LineRenderer LeftHandBeam;
        public LineRenderer RightHandBeam;

        public float LeftCharge = 1f;
        public float RightCharge = 1f;

        public void Awake()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Player/Beam");

            LeftHandBeam = Instantiate(prefab, transform).GetComponent<LineRenderer>();
            RightHandBeam = Instantiate(prefab, transform).GetComponent<LineRenderer>();

            LeftHand = transform.Find("LeftHand");
            RightHand = transform.Find("RightHand");
        }

        public void Start()
        {
            LeftHandBeam.enabled = false;
            RightHandBeam.enabled = false;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine("FireLeftLaser");
                StartCoroutine("FireLeftLaser");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                StopCoroutine("FireRightLaser");
                StartCoroutine("FireRightLaser");
            }
        }

        IEnumerator FireLeftLaser()
        {
            LeftHandBeam.enabled = true;

            while (Input.GetMouseButton(0) && LeftCharge > 0)
            {
                if (LeftCharge <= 0)
                    break;

                Ray ray = new Ray(LeftHand.position, transform.forward);
                LeftHandBeam.SetPosition(0, LeftHand.position);
                LeftHandBeam.SetPosition(1, ray.GetPoint(100));

                yield return null;
            }

            LeftHandBeam.enabled = false;
        }

        IEnumerator FireRightLaser()
        {
            RightHandBeam.enabled = true;

            while (Input.GetMouseButton(1) && RightCharge > 0)
            {
                Ray ray = new Ray(RightHand.position, transform.forward);
                RightHandBeam.SetPosition(0, RightHand.position);
                RightHandBeam.SetPosition(1, ray.GetPoint(100));

                yield return null;
            }

            RightHandBeam.enabled = false;
        }
    }
}
