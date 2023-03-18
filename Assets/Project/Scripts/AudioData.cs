using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    [System.Serializable]
    public class AudioData
    {
        public AudioClip Sound;
        [Range(0f, 1f)]
        public float Volume;
    }
}