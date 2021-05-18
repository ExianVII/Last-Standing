using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] private string Change_Level;

    void OnTriggerPlayer(CircleCollider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            SceneManager.LoadScene(Change_Level);
        }

    }
}
