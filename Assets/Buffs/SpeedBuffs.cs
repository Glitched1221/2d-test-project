using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff" )]
public class SpeedBuffs : PowerScript
{
    public float amount;
    public RigidbodyMovement rigidbodyMovement;
    public override void Apply(GameObject target)
    {
        target.GetComponent<RigidbodyMovement>().intailSpeed *= amount;
    }
}
