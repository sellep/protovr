using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Behaviour.World
{

    public class SpawnableAreaBehaviour : MonoBehaviour
    {

        public int Targets = 5;
        public int PositionMultiplier = 50;

        private int _Current = 0;
        private GameObject _TargetPrefab;

        public void Awake()
        {
            _TargetPrefab = Resources.Load<GameObject>("Prefabs/World/Target");
        }

        public void Update()
        {
            while (_Current < Targets)
            {
                GameObject target = Instantiate(_TargetPrefab, transform);

                target.transform.localPosition = new Vector3(
                    (UnityEngine.Random.value - .5f) * PositionMultiplier,
                    (UnityEngine.Random.value - .5f) * PositionMultiplier,
                    (UnityEngine.Random.value - .5f) * PositionMultiplier);

                _Current++;
            }
        }

        public void OnTargetHit(GameObject target)
        {
            Destroy(target);
            _Current--;
        }
    }
}
