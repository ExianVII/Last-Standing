using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.BackgroundScripts
{
    class PauseController : MonoBehaviour
    {
        
        //GameObject containing the canvas with the pause scene
        public GameObject PauseCanvas;

        //INstantiate the canvas state
        private void Start()
        {
            PauseCanvas.SetActive(false);
        }

        //Invoking the pause scene
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.P))
            {
                Pause();
            } 
        }

        void Pause()
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            

        }

        void Resume()
        {
            Time.timeScale = 1f;
            PauseCanvas.SetActive(false);

        }
        public void OnButtonPress()
        {
            Resume();
        }
                
    }
}
