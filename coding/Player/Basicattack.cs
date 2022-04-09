using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicattack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StartTimeBtwAttack = 0;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    private int damage;
    private int damagemin = 10;
    private int damagemax = 15;
    public Animator anim;
    private Walking move;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<Walking>();
     }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            move.enabled = true;

            if (Input.GetKeyDown(KeyCode.J))
            {
                move.DisableMove();
                move.enabled = false;
                anim.SetTrigger("attack");
                timeBtwAttack = StartTimeBtwAttack;
                damage = Random.Range(damagemin, damagemax);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enermy>().TakeDamge(damage);
                    Debug.Log(damage);
                }
                
            }
            

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
