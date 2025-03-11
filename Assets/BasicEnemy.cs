using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject player;
    public float damage;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindWithTag("Player");
    }
    private void OnCollisionStay2D(Collision2D collison)
    {
        if (timer <= 0f)
        {
        if (collison.gameObject.CompareTag("Player"))
        {
            collison.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Debug.Log("Hit");
            timer= 0.2f;
        }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
         timer -= Time.deltaTime;

    }

    
}
