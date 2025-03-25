using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;



public class Bossscript : MonoBehaviour
{
     NavMeshAgent agent;
    GameObject player;
    public Transform target;
    public float damage;
    public float timer;
     public GameObject bulletprefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float rotateSpeed = 0.0025f;

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

    void Shoot()
    { 
        
        
        {
    
            GameObject bullet = Instantiate(bulletprefab, bulletSpawnPoint.position, firePointRotation.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePointRotation.right * bulletSpeed;
            Destroy(bullet, 3f);
            

        }
        
    }

    private void Update()
    {
        if(!target)
        {
        GetTarget();
        } 
        else
        {
            RotateTowardsTarget();
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    
    }
    private void RotateTowardsTarget()
    {
      Vector2 targetDirection = target.position - transform.position;
      float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg- 90f;
      Quaternion q = Quaternion.Euler(new Vector3(0,0, angle));
      transform.localRotation = Quaternion.Slerp(transform.localRotation,q,rotateSpeed);
    }
}
