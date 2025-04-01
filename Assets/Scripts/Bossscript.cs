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
    public float shoottimer;
     public GameObject bulletprefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;
    public Transform bulletSpawnPoint4;
    public Transform bulletSpawnPoint5;
    public Transform bulletSpawnPoint6;
    [SerializeField] private LayerMask PlayerLayer;



    public float bulletSpeed;
    public float rotateSpeed = 0.0025f;

    // Start is called before the first frame update
    void Start()
    {
        shoottimer = 5f;
        
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;
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
            GameObject bullet = Instantiate(bulletprefab, bulletSpawnPoint1.position, firePointRotation.rotation);
            Instantiate(bulletprefab, bulletSpawnPoint2.position, firePointRotation.rotation);
            Instantiate(bulletprefab, bulletSpawnPoint3.position, firePointRotation.rotation);
            Instantiate(bulletprefab, bulletSpawnPoint4.position, firePointRotation.rotation);
            Instantiate(bulletprefab, bulletSpawnPoint5.position, firePointRotation.rotation);
            Instantiate(bulletprefab, bulletSpawnPoint6.position, firePointRotation.rotation);
           shoottimer = 3f; 

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            //rb.velocity = firePointRotation.forward * bulletSpeed;
            Destroy(bullet, 3f);
            //bulletSpeed
        }
    }

    public void Update()
    {
        shoottimer -= Time.deltaTime;
        if(!target)
        {
        GetTarget();
        } 
        else
        {
            RotateTowardsTarget();
        }
        //ycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5f, PlayerLayer);
        if (shoottimer <= 0f)
        {
            Shoot();
        }
         
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

    //RaycastHit2D raycastHit = Physics2D.Raycast(transform.localRotation);


}
