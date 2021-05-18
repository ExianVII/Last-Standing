using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GameControls.SceneScripts
{
    class TimerStart : MonoBehaviour
    {
        public float TimeLeft = 120f;


        float minutes;
        float seconds;


        public GameObject DisplayTimeLeft;
        static bool activated = false;
        bool CrossFinal;
        [SerializeField] private Vector3 FinishPos = new Vector3(192.0f, 0.0f, 0.0f);
        private Transform player;



        private void Awake()
        {
            DisplayTimeLeft.GetComponent<Text>().text = "Time Remaining : " + TimeLeft.ToString("0.00");
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        private void Start()
        {
            activated = true;

        }

        private void Update()
        {
            
            if (activated)  //to set on Plaza scene and fortress if needed
            {
                TimeLeft -= Time.deltaTime;

                minutes = TimeLeft / 60;
                seconds = TimeLeft % 60;
                

                DisplayTimeLeft.GetComponent<Text>().text = "Time Left : " + minutes.ToString("##") + seconds.ToString(".#");

                if(TimeLeft >= 0 && CharacterScripts.EnemyScripts.FindingEnemies.returnRemaining() == 0)
                {
                    if((player.position.x - FinishPos.x) <= 0)
                    {
                        if(SceneManager.GetActiveScene().Equals("PlazaScene"))
                        SceneLoader.LoadFortress();

                        else if (SceneManager.GetActiveScene().Equals("FortressScene"))
                            SceneLoader.LoadWin();
                    }

           
                }

                if (TimeLeft < 0 && CharacterScripts.EnemyScripts.FindingEnemies.returnRemaining() != 0 && !CrossFinal)
                {
                    SceneLoader.GameOver();
                }
            }
        }
    }
}
