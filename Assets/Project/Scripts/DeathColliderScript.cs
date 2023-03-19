using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class DeathColliderScript : MonoBehaviour
    {
        public GameController Game;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnCollisionEnter2D(Collision2D coll)
        {
            if(coll.gameObject.GetComponent<BugController>())
            {
                Game.TriggerDeath();
                //Debug.Log("Death");
            }
        }

    }
}