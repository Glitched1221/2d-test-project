using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
       RotateBulletSpawnPointTowardsMouse();

       if(Input.GetButtonDown("Fire1"))
       {
             Shoot();


       }
        
    }

    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePostion - firePointRotation.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;

        Destroy(bullet, 3f);
    }

    




}
