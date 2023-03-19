using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pestcal
{
    public class CompileButton : MonoBehaviour
    {

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                SceneManager.LoadScene(1);
            }
        }
        private void OnMouseDown()
        {
            SceneManager.LoadScene(1);
        }
    }
}
