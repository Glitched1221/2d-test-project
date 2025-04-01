using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeddd : MonoBehaviour
{
     public float Speedboost = 0.05f;
    public float SpeedBoostLength = 2f;

    public RigidbodyMovement rigidbodyMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }

}
