using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuffs")]
public class HealthBuff : PowerScript
{
    public PlayerHealth playerHealth;
    
    public float amount;
  

    public override void Apply(GameObject target)

    {
        target.GetComponent<PlayerHealth>().PHP += playerHealth.PmaxHealth/5 * amount;


    }
}
