using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pestcal
{
    public class SpawnVisualizerController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

        }
        public void SetWidthByUnits(int units)
        {
            if(_spriteRenderer == null)
            {
                return;
            }

            _spriteRenderer.size = new Vector2(units, _spriteRenderer.size.y);
        }
    }
}