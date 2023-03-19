using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pestcal
{
    public class EditPageItemScript : MonoBehaviour
    {
        public TMP_Text Name;
        public TMP_Text Cost;

        public void Start()
        {
            Init();
        }
        private void Init()
        {
            Name = GetComponent<TMP_Text>();
            Cost = GetComponent<TMP_Text>();
        }
        public void SetDetails(string name, int cost)
        {
            Name.text = name;
            Cost.text = cost.ToString();
        }

        private void OnMouseEnter()
        {
            //Debug.Log("Mouse on");
        }
    }
}