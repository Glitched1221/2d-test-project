using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammopack : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            

        }
    }
}
