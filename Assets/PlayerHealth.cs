using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int PmaxHealth;
    public float PHP;
    public Image healthBar;
    void Start()
    {
        
        PHP = PmaxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        PHP -= damage;
        Debug.Log(gameObject.name + " Damage taken");

        if (PHP <= 0)
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
    void Update()
    {
      healthBar.fillAmount = PHP/PmaxHealth;
    }    

}
