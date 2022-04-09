using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float timerbtwSpawn;
    private float timer;
    public GameObject Monster;
    public int Monsteramount;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Monsteramount > 0)
        {
            timer += Time.deltaTime;
            if (timer >= timerbtwSpawn)
            {
                timer = 0;

                spawn();
            }

        }
       
    }

    void spawn()
    {
        
        Instantiate(Monster, transform.position, Quaternion.identity, transform.parent);
        Monsteramount--;
    }
}
