using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManger : MonoBehaviour
{
   
    public static int killcount = 0;
    public Text Killcount;
    
    // Update is called once per frame
    void Update()
    {
        Killcount.text = killcount.ToString();
    }
}