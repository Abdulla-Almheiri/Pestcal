using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class BulletScript : MonoBehaviour
    {
        public float Speed = 5f;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 15f);
        }

        // Update is called once per frame
        void Update()
        {
            ProcessMovement();

        }

        public void SetSpeed(float value)
        {
            Speed = value;
        }
        private void ProcessMovement()
        {
            transform.localPosition += new Vector3(0f, Time.deltaTime * Speed *-1, 0f);
        }
    }
}