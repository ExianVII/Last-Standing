using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int level = 0;
    void Update()
    {
        string SceneName = SceneManager.GetActiveScene().name;

        
         if (SceneName == "PlazaScene")
            level = 1;
        //if the Update method detects the game is on the fortress Scene (which is like 
        //our final level, it will set our level number as 2 and let mosters use their 
        //second skill)

        else if (SceneName == "FortressScene")
            level = 2;
    }
}

