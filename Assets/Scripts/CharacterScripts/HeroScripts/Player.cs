using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int health = 100;
    }
    [SerializeField] private float fallBoundary = -14;
    [SerializeField] private float jumpBoundary = 11;
    public PlayerStats player = new PlayerStats();


    private void Update()
    {
        if(transform.position.y <= fallBoundary ||
            transform.position.y > jumpBoundary)
        {
            DamageTaken(999999);
        }
    }

    //damage function
    public void DamageTaken(int damage)
    {
        player.health -= damage;

        if (player.health <= 0)
        {
            GameControl.KillPlayer(this);
        }
    }

}
