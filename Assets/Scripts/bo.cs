using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bo : MonoBehaviour
{
    // Start is called before the first frame update
    
      public int ammo;
    public PlayerShooting Player;
    public Text BulletCount;
    public int ammoinclip;
    public Text AmmoInClip;
      void Update()
    {
        BulletCount.text = ammo.ToString();
        ammo = Player.currentAmmo;
        AmmoInClip.text = ammoinclip.ToString();
        ammoinclip = Player.currentClip;
       
    }

}
