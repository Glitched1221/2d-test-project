using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcollideddeath : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            
            Destroy(gameObject);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
