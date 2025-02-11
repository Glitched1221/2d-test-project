using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    
    public float maxHealth;
    float HP;
    void Start()
    {
        
        HP = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log(gameObject.name + " Damage taken");

        if (HP <= 0)
        {
            Die();
        }
       

    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Destroyyed");
        Debug.Log("Time taken" + Time.time);
    }
    

}
