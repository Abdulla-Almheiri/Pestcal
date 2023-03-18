using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    [CreateAssetMenu(fileName ="new game audio template", menuName ="Game Content/Game Audio Template")]
    public class GameAudioTemplate : ScriptableObject
    {
        public AudioData Confirm;
        public AudioData Cancel;
        public AudioData Error;
        public AudioData Shoot;
        public AudioData BugDeath;
        public AudioData Win;
        public AudioData Lose;

    }
}