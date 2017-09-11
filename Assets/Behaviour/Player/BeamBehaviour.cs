using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.Player
{

    public class BeamBehaviour : MonoBehaviour
    {
        public float Lifetime = 0.1f;
        public float Endtime;

        public void Start()
        {
            Endtime = Time.time + Lifetime;
        }

        public void Update()
        {
            if (Time.time > Endtime)
            {
                Destroy(gameObject);
            }
        }
    }
}
