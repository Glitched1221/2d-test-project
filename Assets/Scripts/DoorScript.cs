using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform level3;
    public GameObject doorspike;
    public int numForDoorToWin;
    public EnemySpawnerL2 es;
    public BulletManger bm;
    public GameObject boss;

    
    // Start is called before the first frame update
    void Start()
    {
        numForDoorToWin = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(BulletManger.killcount >= numForDoorToWin)
        {
            doorspike.SetActive(false);
        }    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Resetkillcount();
            es.StopSpawning();
            other.transform.position = level3.position;
            es.DestoyObjects();
            boss.SetActive(true);


            
           
        }
        
    }
    void Resetkillcount()
    {
     BulletManger.killcount = 0;

    }
    // public static int killcount = 0;
}
