using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    public class TargetBehaviour : MonoBehaviour
    {

        private GameObject _Player;

        public void Awake()
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }

        public void Update()
        {
            transform.LookAt(_Player.transform);
        }
    }
}
