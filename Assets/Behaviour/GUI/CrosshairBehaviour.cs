using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.GUI
{

    [RequireComponent(typeof(Image))]
    public class CrosshairBehaviour : MonoBehaviour
    {

        public Vector2 ScreenMiddle;

        public void Awake()
        {
            ScreenMiddle = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        public void Start()
        {

        }

        public void OnGUI()
        {
            
        }
    }
}
