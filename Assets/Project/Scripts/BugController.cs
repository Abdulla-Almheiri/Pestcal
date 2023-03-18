using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class BugController : MonoBehaviour
    {
        private float baseSpeed = 1f;
        private float currentSpeed = 1f;
        private int maxHealthPoints = 3;
        private int currentHealthPoints = 3;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(0f, Time.deltaTime * currentSpeed, 0f);
        }

        public void Init(BugTemplate template)
        {
            baseSpeed = template.BaseSpeed;
            currentSpeed = baseSpeed;

            maxHealthPoints = template.BaseHealthPoints;
            currentHealthPoints = template.BaseHealthPoints;
        }
    }
}