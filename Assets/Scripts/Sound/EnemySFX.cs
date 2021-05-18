using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemySFX : MonoBehaviour
{

    public AudioSource EnemyAttack;
    public AudioClip audio1;
    AnimationState atckState;
    GameObject[] monsters;


    // Start is called before the first frame update
    void Start()
    {
        EnemyAttack.clip = audio1;

        monsters = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {/*
        foreach(GameObject mon in monsters)
        {
            if()
        }*/
    }
}
