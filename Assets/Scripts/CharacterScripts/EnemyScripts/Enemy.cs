using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{ 
    [SerializeField] private float fallBoundary = -14;
    [SerializeField] private float jumpBoundary = 11;
    public EnemyStatusManager enemy = new EnemyStatusManager();

//public Enemy enemy;

    private void Start()
    {

    }


    private void Update()
    {
        if (transform.position.y <= fallBoundary ||
        transform.position.y > jumpBoundary)
        {
        enemy.EnemyTakeDamage(999999);
        }

        if (enemy.HealthBar.value <= 0)
        {
            Kill();
        }
    }



    //damage function trigger
    public void DamageDone(int damage)
    {
    //Enemy.
    }

    public void Kill()
    {
    GameControl.KillEnemy(this);

    }


}
