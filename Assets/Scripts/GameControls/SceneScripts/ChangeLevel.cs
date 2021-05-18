using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    GameObject hero;
    int enemiesLeft;

    // Start is called before the first frame update
    void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft = Assets.Scripts.CharacterScripts.EnemyScripts.FindingEnemies.returnRemaining();

        if (LevelManager.level == 1 && enemiesLeft == 0)
        {
            if (hero.transform.position.x > 192)
            {
                SceneLoader.LoadFortress();
            }
                
        }

        if (LevelManager.level == 2 && enemiesLeft == 0)
        {
            if (hero.transform.position.x > 244)
            {
                SceneLoader.LoadWin();
            }

        }

    }
}
