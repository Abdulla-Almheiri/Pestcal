using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class BugSpawnerController : MonoBehaviour
    {
        public GameObject PrefabToSpawn;
        public BugSpawnerTemplate SpawnerTemplate;
        public SpawnVisualizerController SpawnVisualizer;
        public GameController Game;
        private int _defaultObjectPoolCount = 64;
        private int _spawnWidthInUnits = 4;
        private float _spawnWidthInPixels = 80f;
        private float _baseSpawnRate = 0.4f;
        private float _spawnCounter = 1f;

        private bool _isPaused = false;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
           /* if(Input.GetKeyUp(KeyCode.S))
            {
                SpawnPrefabAtPoint();
            }*/
            ProcessSpawning();
        }
        public void Init()
        {
            if(SpawnerTemplate == null)
            {
                return;
            }

            _spawnWidthInUnits = SpawnerTemplate.SpawnWidthInUnits;
            _spawnWidthInPixels = SpawnerTemplate.GetSpawnWidthInPixels();
            SpawnVisualizer.SetWidthByUnits(_spawnWidthInUnits);
            _spawnCounter = 1f / _baseSpawnRate;

            //Debug.Log(_spawnWidthInUnits);
        }
        public void StartSpawning(float rate = 1f)
        {

        }

        private void SpawnPrefabAtPoint()
        {
            if(_isPaused == true)
            {
                return;
            }

            var spawn = Instantiate(PrefabToSpawn, transform);
            var spawnPoint = new Vector2(Random.Range(-_spawnWidthInUnits / 2f, _spawnWidthInUnits / 2), 0f);

            spawn.transform.localPosition = spawnPoint;
            spawn.GetComponent<BugController>().IncreaseSpeed(1 + (Game.DifficultyLevel / 10f));
            spawn.transform.SetParent(Game.BugContainer.transform);
            IncreaseSpawnRate();
            
        }

        public void SetPauseState(bool value)
        {
            _isPaused = value;
        }

        private void ProcessSpawning()
        {
            if (_spawnCounter > 0f)
            {
                _spawnCounter -= Time.deltaTime;
            }
            else
            {
                SpawnPrefabAtPoint();
                _spawnCounter = 1 / _baseSpawnRate;
            }
        }


        private void IncreaseSpawnRate()
        {
            _baseSpawnRate += (Game.DifficultyLevel / 100f);
        }

    }
}