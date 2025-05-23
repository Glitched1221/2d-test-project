using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public float firecooldown;
    public float colldownshoot;
    public TimeManager timeManager;
    public GameObject bulletprefab;
    public Transform firePointRotation;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;
    public int currentClip, maxClipSize = 10, currentAmmo, MaxAmmoSize = 100;
    public int SetAmmo;
    public float weapon;
    public int damage = 5;
    public BulletManger bm;
    public float weapondamage;
    public bo bo;
    public float shoottimer;

    public weaponstate state;
    public enum weaponstate
    {
        pistol,
        shotgun
    }
    
    

    


    // Update is called once per frame
    void Start()
    {
          currentClip = 10;
          state = weaponstate.pistol;
    }
    void Update()
    {
        colldownshoot -= Time.deltaTime;
         

        if(Gmcode.GameIsPaused)
           return;
       RotateBulletSpawnPointTowardsMouse();

         if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
       }
    //    if(Input.GetButton("Fire1") && shoottimer <= 0)
    //    {
    //     Shoot();
    //     shoottimer =0.2f;
    //    }
       shoottimer -= Time.deltaTime;
       if(Input.GetKeyDown(KeyCode.R))
       {
        Reload();
       } 
       if(Input.GetKeyDown(KeyCode.C))       
       {
        timeManager.DoSlowMotion();
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
        
        if (currentClip > 0 )
        {
        //    if (colldownshoot > 0)
        //         return;
            GameObject bullet = Instantiate(bulletprefab, bulletSpawnPoint.position, firePointRotation.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePointRotation.right * bulletSpeed;
            Destroy(bullet, 3f);
            currentClip--;
            bo.ammo --;
            colldownshoot = firecooldown;

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

    private void StateHandler()
    {
        
    }
   
      
}
