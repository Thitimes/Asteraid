using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enermy : CharacterStat
{


    public int Enemy;
    public int currrentEnemy;
    public int Enemy2;
    public Transform parentTrans;
    public PlayerStat PlayerStat;
    public static int CurrentEnemydie = 0;
    private static int score = 0;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    // Update is called once per frame
    void Update()
    {
       //if(currrentEnemy < Enemy)
       // {
       //     CurrentEnemydie = score + 1;
       //     Enemy2 = Enemy - 1;
       //     Enemy = Enemy2;
       // }

        if (currentHealth <= 0)
        {
            
            Enemydie();
            
           

        }
    }
    public void Enemydie()
    {
        Destroy(parentTrans.gameObject);
    }
    
}
