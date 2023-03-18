using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class GunScript : MonoBehaviour
    {
        public float BaseMovementSpeed = 1f;
        public float LeftXValue = 2.77f;
        public float RightXValue = 7.68f;
        public float ShootingRate = 1f;

        public GameController Game;
        public GameObject Laser;
        public GameObject BulletPrefab;


        private int _direction = 1; //1 is right, -1 is left
        private float _shootingCooldown = 1f;

        // Start is called before the first frame update
        void Start()
        {
            _shootingCooldown = 1 / ShootingRate;
        }

        // Update is called once per frame
        void Update()
        {
            ProcessGunMovement();
            ProcessShooting();
        }

        private void ProcessShooting()
        {
            if(_shootingCooldown > 0f)
            {
                _shootingCooldown -= Time.deltaTime;
            } else
            {
                InstantiateBullet();
                _shootingCooldown = 1 / ShootingRate;
            }
        }

        private void InstantiateBullet()
        {
            var spawn = Instantiate(BulletPrefab, transform);
            spawn.transform.SetParent(null);

        }

        private void ProcessGunMovement()
        {
            var movementDelta = new Vector3(Time.deltaTime * BaseMovementSpeed * _direction, 0f, 0f);
            transform.Translate(movementDelta);
            if(transform.position.x < LeftXValue || transform.position.x > RightXValue)
            {
                _direction *= -1;

            }
        }

        public void ToggleLaser(bool state)
        {
            if(Laser == null)
            {
                return;
            }

            if(Laser.activeSelf != state)
            {
                Laser.SetActive(state);
            }
        }
    }
}