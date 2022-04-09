using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MonsterBehaviour : MonoBehaviour
{
    public float Speed;
    public GameObject Enemy;
    private GameObject Player;
    private Vector2 velocity = Vector2.zero;
    public float stopDistance = 2f;
    public Animator anim;
    private Vector3 InitialScale;
    public bool isAttacking = false;
    public int damagemin = 10;
    public int damagemax = 15;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    private float timeBtwAttack;
    public float StartTimeBtwAttack = 0;
    private int damage;
    public Transform parentTrans;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        InitialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       



        if (isAttacking)
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetBool("isAttacking", true);
                timeBtwAttack = StartTimeBtwAttack;
                damage = Random.Range(damagemin, damagemax);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                Debug.Log(enemiesToDamage.Length + " enm l");
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Debug.Log("test");
                    enemiesToDamage[i].GetComponent<PlayerStat>().TakeDamge(damage);
                    Debug.Log(damage);
                }

            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }

        }
        
        else
        {
            anim.SetBool("isAttacking", false);
            Moving();
        }
    }
    void Moving()
    {
        Vector3 targetV = (parentTrans.transform.position - Player.transform.position);
        targetV.z = 0;


        if (targetV.magnitude > stopDistance)
        {
        //Debug.Log(parentTrans.name + " : " + targetV.magnitude);
            velocity = (parentTrans.position - Player.transform.position).normalized * Speed;
            //velocity = -velocity;
            //targetV = Player.transform.position;
            //parentTrans.transform.position = targetV;
            Debug.Log(targetV);



        }
        else
        {
            velocity = Vector3.zero;
        }
        parentTrans.GetComponent<Rigidbody2D>().velocity = -velocity;
        if (targetV.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = InitialScale.x;
            transform.localScale = scale;
        }
        else if (targetV.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -InitialScale.x;
            transform.localScale = scale;
        }

        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
}

