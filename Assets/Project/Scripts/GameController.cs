using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Pestcal
{
    public class GameController : MonoBehaviour
    {
        public AudioData UpgradeSound;
        public AudioData LoseSound;

        public GameObject CurrentMessageBox { get; private set; }
        public BugSpawnerController BugSpawner;
        public GunScript Gun;
        public GunScript AdditionalGun;
        public GameObject BugContainer;
        public Canvas Canvas;
        public TMP_Text LoseMessageText;

        public TMP_Text BytesText;
        public EditPageController UpgradesPage;

        public TMP_Text Tooltip;
        public GameObject LoseMessage;
        private bool _isLost = false;
        public bool IsPaused { get; private set; } = false;

        [HideInInspector]
        public int Bytes = 0;
        private float _secondsLasted;
        private float _secondsCounter;
        private AudioSource _audioSource;

        private int _knowledge = 1;
        private int _testDrivenDesign = 1;
        private int _pairProgramming = 1;
        private int _AIDebugger = 1;

        private float _allSpeed = 1f;
        private float _speedUpgradeAmount = 0.05f;

        private bool _automaticShooting;

        private float counter = 1f;

        public float DifficultyLevel = 1;
        private float _difficultyFactor = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        private void Init()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessBytes();
            ProcessRestartGame();
            ProcessSeconds();
        }

        private void ProcessSeconds()
        {
            _secondsLasted += Time.deltaTime;

        }

        private void ProcessRestartGame()
        {
            if(_isLost)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        private void ProcessBytes()
        {
            if(IsPaused || _isLost)
            {
                return;
            }

            DifficultyLevel += (Time.deltaTime * _difficultyFactor);
            counter -= Time.deltaTime;
            if(counter <= 0f)
            {
                Bytes++;
                counter = 1f;
                SetBytesText(Bytes);
            }


        }

        public void SetPauseState(bool state)
        {
            if(IsPaused == state)
            {
                return;
            }

            IsPaused = state;

            //Handle Pause
            //BugSpawner.Pause();
        }

        public bool AttemptPurchase(int bytes)
        {
            if(bytes <= Bytes)
            {
                Bytes -= bytes;
                return true;
            }

            return false;


        }

        public void SetBytesText(int value)
        {
            if(BytesText == null)
            {
                return;
            }

            BytesText.text = "Bytes : " + value.ToString();
        }

        public void PlaySound(AudioData audioData)
        {
            if(_audioSource == null)
            {
                return;
            }
            if(audioData == null || audioData.Sound == null)
            {
                return;
            }

            _audioSource.PlayOneShot(audioData.Sound, audioData.Volume);
        }

        public void ItemHovered(int index)
        {

        }

        public void UpgradePurchased(int index)
        {
            switch(index)
            {
                case 0:
                    TriggerShoot();
                    break;
                case 1:
                    _allSpeed += _speedUpgradeAmount;
                    UpgradeGunAndBulletSpeed();
                    PlaySound(UpgradeSound);
                    break;
                case 2:
                    _automaticShooting = true;
                    Gun.ToggleAutomaticShooting(true);
                    if(AdditionalGun.gameObject.activeSelf)
                    {
                        AdditionalGun.ToggleAutomaticShooting(true);
                    }
                    PlaySound(UpgradeSound);
                    break;
                case 3:
                    ActivateAdditionalGun();
                    PlaySound(UpgradeSound);
                    break;
                case 4:
                    ActivateLasers();
                    PlaySound(UpgradeSound);
                    break;
                default:
                    break;
            }
        }

        public void TriggerDeath()
        {
            if(_isLost)
            {
                return;
            }

            BugSpawner.SetPauseState(true);
            LoseMessage.SetActive(true);
            LoseMessageText.text = "You lost! Your software is too buggy to ship.You lasted " + ((int)_secondsLasted).ToString() + " days.";
            _isLost = true;
            Gun.ToggleAutomaticShooting(false);
            if(AdditionalGun.gameObject.activeSelf)
            {
                AdditionalGun.ToggleAutomaticShooting(false);
            }
            Bytes = 0;
            PlaySound(LoseSound);
        }

        private void UpgradeGunAndBulletSpeed()
        {
            Gun.SetSpeedMultiplier(_allSpeed);
            Gun.SetBulletSpeedMultiplier(_allSpeed);
            AdditionalGun.SetSpeedMultiplier(_allSpeed);
            AdditionalGun.SetBulletSpeedMultiplier(_allSpeed);
        }
        public void ShowTooltip(string text)
        {
            Tooltip.text = text;
            Tooltip.gameObject.SetActive(true);
        }


        public void HideTooltip()
        {
            Tooltip.gameObject.SetActive(false);
        }

        private void ActivateAdditionalGun()
        {
            AdditionalGun.gameObject.SetActive(true);
            if(_automaticShooting)
            {
                AdditionalGun.ToggleAutomaticShooting(true);
            }
        }

        private void ActivateLasers()
        {
            Gun.ToggleLaser(true);
            AdditionalGun.ToggleLaser(true);
        }

        private void TriggerShoot()
        {
            Gun.TriggerManualShoot();
            if(AdditionalGun.gameObject.activeSelf)
            {
                AdditionalGun.TriggerManualShoot();
            }
        }

        public void ClearBugs()
        {
            BugContainer.SetActive(false);
        }
    }
}