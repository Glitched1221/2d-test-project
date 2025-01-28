using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManger : MonoBehaviour
{
    public int ammo;
    public PlayerShooting Player;
    public Text BulletCount;
    
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        BulletCount.text = ammo.ToString();
        ammo = Player.currentAmmo;

    }
}
