using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class EnemyAttack : MonoBehaviour
{
    //Booleans to trigger monsters' attacks
    //bool doBasicAttack;
    //bool doSkill;
    //bool selectAttack = false;

    ////bool to detect hero
    //bool detectHero;

    ////to signal hero's presence on other scripts
    //public static bool holder;
    
    //GameObject charHero;
    //Queue<bool> doWhichAttack = new Queue<bool>();
    

    //int flagSkill = 1;

    //void Start()
    //{ 
    //    doBasicAttack = false;
    //    detectHero = false;
    //    doSkill = false;
    //}

    //public void truth()
    //{
    //    doWhichAttack.Enqueue(selectAttack);
    //    selectAttack = !selectAttack;
    //    doWhichAttack.Enqueue(selectAttack);
    //}

    //void Update()
    //{  
    //    holder = detectHero;

    //    if (detectHero && LevelManager.level == 2)
    //    {
    //        truth();
    //        doSkill = doWhichAttack.Dequeue(); 
    //        doBasicAttack = doWhichAttack.Dequeue();
    //    }
    //    else if (detectHero)
    //    {
    //        doBasicAttack = true;
    //    }
    //    else
    //    {
    //        doBasicAttack = false;
    //        doSkill = false;
    //    }

    //    this.GetComponent<Animator>().SetBool("doBasicAttack", doBasicAttack);
    //    this.GetComponent<Animator>().SetBool("doSkill", doSkill);        
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    charHero  = other.transform.gameObject;
        
    //    if (charHero.tag == "Player")
    //    {
    //        detectHero = true;

    //        if (charHero.transform.position.x < this.transform.position.x && !EnemyMove.returnFlip())
    //        {
    //           // this.gameObject.GetComponent<EnemyMove>().Flip();
    //        }
    //        else if (charHero.transform.position.x > this.transform.position.x && !EnemyMove.returnFlip())
    //        {
    //            //this.gameObject.GetComponent<EnemyMove>().Flip();
    //        }
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    detectHero = false;
    //}
   
}
