using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManger : MonoBehaviour
{
    public int ammo;
    public PlayerShooting Player;
    public Text BulletCount;
    public int ammoinclip;
    public Text AmmoInClip;
    public int killcount;
    public Text Killcount;
    
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        BulletCount.text = ammo.ToString();
        ammo = Player.currentAmmo;
        AmmoInClip.text = ammoinclip.ToString();
        ammoinclip = Player.currentClip;
        Killcount.text = killcount.ToString();

    }
}
