using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //this script will contain all scenes loaders and it will let other
    //scripts load scenes calling those static loaders
   public static void LoadSuburbs()
    {
        SceneManager.LoadScene("SuburbsScene");
    }

    public static void LoadPlaza()
    {
        SceneManager.LoadScene("PlazaScene");
    }

    public static void LoadFortress()
    {
        SceneManager.LoadScene("FortressScene");
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("InsertName");
    }

    public static void EndGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
