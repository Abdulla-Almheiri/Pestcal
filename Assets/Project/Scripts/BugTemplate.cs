using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    [CreateAssetMenu(fileName = "new bug template", menuName = "Game Content/Bug Template")]
    public class BugTemplate : ScriptableObject
    {
        public float BaseSpeed = 1f;
        public int BaseHealthPoints = 3;

    }
}