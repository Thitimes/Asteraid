using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public MonsterBehaviour monsterBe;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            monsterBe.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            monsterBe.isAttacking = false;
        }
    }
}

