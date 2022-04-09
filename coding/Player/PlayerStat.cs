using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : CharacterStat
{
    public int Enemy;
    //public int CurrentEnemy;
    public int Enemykilled;

    // Start is called before the first frame update
    void Start()
    {
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Enemykilled = Enermy.CurrentEnemydie;
        if  (Enemy == 0)
        {
            
                SceneManager.LoadScene("Win");
            
        }
        
        if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
            SceneManager.LoadScene("Lose");
        }
    }
}
