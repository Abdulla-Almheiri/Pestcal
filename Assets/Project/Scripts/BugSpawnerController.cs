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

        private int _defaultObjectPoolCount = 64;
        private int _spawnWidthInUnits = 4;
        private float _spawnWidthInPixels = 80f;

        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.S))
            {
                SpawnPrefabAtPoint();
            }
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

            Debug.Log(_spawnWidthInUnits);
        }
        public void StartSpawning(float rate = 1f)
        {

        }

        private void SpawnPrefabAtPoint()
        {
            var spawn = Instantiate(PrefabToSpawn, transform);
            var spawnPoint = new Vector2(Random.Range(-_spawnWidthInUnits / 2f, _spawnWidthInUnits / 2), 0f);

            spawn.transform.localPosition = spawnPoint;
            
        }

        public void PauseSpawning()
        {

        }

        private void ProcessSpawning()
        {

        }


    }
}