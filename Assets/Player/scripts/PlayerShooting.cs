using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    public int currentClip, maxClipSize = 10, currentAmmo, MaxAmmoSize = 100;
    public float weapon;

    


    // Update is called once per frame
    void Start()
    {
          currentClip = 10;
    }
    void Update()
    {
       RotateBulletSpawnPointTowardsMouse();

       if(Input.GetButtonDown("Fire1"))
       {
            Shoot();
       }
       if(Input.GetKeyDown(KeyCode.R))
       {
        Reload();
       }

        
    }

    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePostion.z = 0f;

        Vector2 direction = (mousePostion - firePointRotation.position).normalized;
        mousePostion.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }

    void Shoot()
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(bulletprefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        Destroy(bullet, 3f);
        currentClip--;
        }

        


        
    }
    public void Reload()
    {
        int relaodAmount = maxClipSize - currentClip;
        relaodAmount = (currentAmmo - relaodAmount) >=0 ? relaodAmount : currentAmmo;
        currentClip += relaodAmount;
        currentAmmo -= relaodAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > MaxAmmoSize)
        {
            currentAmmo = MaxAmmoSize;
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ammo"))
        {
            currentAmmo = 100;
            

        }
    }



}