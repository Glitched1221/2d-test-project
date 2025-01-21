using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject player;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.gameObject.CompareTag("Player"))
        {
            collison.gameObject.GetComponent<Health>()?.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    
}
