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
        public AudioData BulletSound;

        private int _direction = 1; //1 is right, -1 is left
        private float _shootingCooldown = 1f;
        private float _manualShootingCounter = 0f;
        private float _manualShootingCooldown = 0.1f;
        private bool _automaticShooting = false;

        private float _bulletSpeedMultiplier = 1f;
        private float _speedMultiplier = 1f;
        // Start is called before the first frame update
        void Start()
        {
            _shootingCooldown = 1f / ShootingRate;
        }

        // Update is called once per frame
        void Update()
        {
            ProcessGunMovement();
            ProcessAutomaticShooting();
            ProcessManualShooting();
        }

        private void ProcessManualShooting()
        {
            if(_manualShootingCounter > 0f)
            {
                _manualShootingCounter -= Time.deltaTime;
            }
        }
        private void ProcessAutomaticShooting()
        {
            if(_automaticShooting == false)
            {
                return;
            }

            if(_shootingCooldown > 0f)
            {
                _shootingCooldown -= Time.deltaTime;
            } else
            {
                InstantiateBullet();
                _shootingCooldown = 1f / ShootingRate;
            }
        }

        private void InstantiateBullet()
        {
            var spawn = Instantiate(BulletPrefab, transform);
            spawn.transform.SetParent(null);
            spawn.GetComponent<BulletScript>().SetSpeedMultiplier(_bulletSpeedMultiplier);
            Game.PlaySound(BulletSound);

        }

        public void TriggerManualShoot()
        {
            if(_manualShootingCounter > 0f)
            {
                return;
            }

            InstantiateBullet();
            _manualShootingCounter = _manualShootingCooldown;
        }
        private void ProcessGunMovement()
        {
            var movementDelta = new Vector3(Time.deltaTime * BaseMovementSpeed * _direction * _speedMultiplier, 0f, 0f);
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

        public void SetSpeedMultiplier(float value)
        {
            _speedMultiplier = value;
        }

        public void SetBulletSpeedMultiplier(float value)
        {
            _bulletSpeedMultiplier = value;
            ShootingRate = value;
            Debug.Log("Shooting Rate  :  " + ShootingRate);
        }

        public void ToggleAutomaticShooting(bool state)
        {
            _automaticShooting = state;
        }
    }
}