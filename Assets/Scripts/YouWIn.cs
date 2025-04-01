using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{   
    public Gmcode HUD;


    
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
              Gmcode.winn = true;   
        }
        
    }
}
