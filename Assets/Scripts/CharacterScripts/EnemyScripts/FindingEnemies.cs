using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CharacterScripts.EnemyScripts
{
    class FindingEnemies : MonoBehaviour
    {
        GameObject[] enemies;
        static int remainEnemies;

        public void Update()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            remainEnemies = enemies.ToList().Count();
        }

        public static int returnRemaining()
        {
            return remainEnemies;
        }
    }
}
