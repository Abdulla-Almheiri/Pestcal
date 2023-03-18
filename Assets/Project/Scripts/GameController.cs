using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pestcal
{
    public class GameController : MonoBehaviour
    {
        public GameObject CurrentMessageBox { get; private set; }
        public GameObject BugSpawner;
        public GunScript Gun;
        public TMP_Text BytesText;
        public bool IsPaused { get; private set; } = false;

        [HideInInspector]
        public int Bytes = 0;

        private AudioSource _audioSource;

        private int _typingSpeed = 1;
        private int _knowledge = 1;
        private int _testDrivenDesign = 1;
        private int _pairProgramming = 1;
        private int _AIDebugger = 1;

        private float counter = 1f;

        public float DifficultyLevel = 1;
        private float _difficultyFactor = 0.5f;

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
        }

        private void ProcessBytes()
        {
            if(IsPaused)
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

        public void AttemptPurchase()
        {

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

            _audioSource.PlayOneShot(audioData.Sound);
        }

        public void ItemHovered(int index)
        {

        }

        public void ItemClicked(int index)
        {

        }
    }
}