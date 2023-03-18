using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    [CreateAssetMenu(fileName = "new bug spawner template", menuName = "Game Content/Bug Spawner Template")]
    public class BugSpawnerTemplate : ScriptableObject
    {
        public float VarianceInSpawnRate = 0f;
        public int SpawnWidthInUnits = 5;
        public float UnitSize = 16f;

        public float GetSpawnWidthInPixels()
        {
            return UnitSize * SpawnWidthInUnits;
        }
    }
}
