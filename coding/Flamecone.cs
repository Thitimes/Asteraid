using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamecone : MonoBehaviour
{
    public GameObject Flame;
    public Transform SpawnPos;
    private int damage;
    private int damagemin = 30;
    private int damagemax = 35;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    private float timeBtwAttack;
    public float StartTimeBtwAttack ;
    private Walking move;

    public float DestroyTime = 3f;

    void Start()
    {
        
        move = GetComponent<Walking>();
    }


    // Update is called once per frame
    void Update()
    {
       
           
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                if (timeBtwAttack <= 0)
                {
                    damage = Random.Range(damagemin, damagemax);
                    timeBtwAttack = StartTimeBtwAttack;
                    GameObject Flamecone = Instantiate(Flame, SpawnPos.position, Quaternion.identity, SpawnPos);
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Enermy>().TakeDamge(damage);
                        Debug.Log(damage);
                    }
                    Destroy(Flamecone, DestroyTime);
                }


            }
            else
            {

                timeBtwAttack -= Time.deltaTime;
               
            }


        }

    }
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackPos.position, attackRange);
    //}

}
