using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int PmaxHealth;
    public float PHP;
    public Image healthBar;
    public Gmcode HUD;
    void Start()
    {
        
        PHP = PmaxHealth;
        HUD.UpdateHealthBar(PHP / PmaxHealth);
    }
    
    public void TakeDamage(float damageAmount)
    {
        PHP -=damageAmount;
        Debug.Log(gameObject.name + " Damage taken");
        HUD.UpdateHealthBar(PHP/PmaxHealth);

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
