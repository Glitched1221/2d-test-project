using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyBullet : MonoBehaviour
{
    public float timer;
    public int damage = 10;
    NavMeshAgent agent;
    GameObject player;
    public float lifespan;

    void Start()
    {
        //Destroy(gameObject, 3f);
        lifespan = 5f;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindWithTag("Player");


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {                
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);

                Debug.Log("Hit");
                timer = 0.2f;
                Destroy(gameObject);
            

            
         
         
        }
        
        if (collision.gameObject.CompareTag("Bullet"))
            return;
        if (collision.gameObject.CompareTag("Boss"))
        {
           return;

        }
        Destroy(gameObject);
    }
    
  void Update()
  {
    timer -= Time.deltaTime;
    lifespan -= Time.deltaTime;
    agent.SetDestination(player.transform.position);

    if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }



    }
}
