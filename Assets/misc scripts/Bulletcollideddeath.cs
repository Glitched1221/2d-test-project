using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcollideddeath : MonoBehaviour
{
    public int damage =5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>()?.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }

}
