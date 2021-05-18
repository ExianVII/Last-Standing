using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CharacterScripts.EnemyScripts
{
    class DisplayNbEnemies : MonoBehaviour
    {
        public GameObject textDisplay;

        private void Start()
        {
            textDisplay.GetComponent<Text>().text = "Enemies Left: " + 0;
        }

        void Update()
        {
            textDisplay.GetComponent<Text>().text = "Enemies Left: " + FindingEnemies.returnRemaining();
        }
    }
}
