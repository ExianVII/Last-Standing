using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusManager : MonoBehaviour
{
    public Slider HealthBar;
    public float Health = 100;

    private float currentHealth;


    public EnemyStatusManager status;
    private void Start()
    {

        currentHealth = Health;

    }

    public void EnemyTakeDamage(float damage)
    {
        currentHealth -= damage;
        HealthBar.value = currentHealth;

    }


}
