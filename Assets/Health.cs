using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    
    public int maxHealth;
    int HP;
    void Start()
    {
        
        HP = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Damge taken");

        if (HP <= 0)
        {
            Die();
        }
        if (HP <= 5)
        {
         Debug.LogWarning("Enemy Low health");
        }

    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Destroyyed");
        Debug.Log("Time taken" + Time.time);
    }
    

}
