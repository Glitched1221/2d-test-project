using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
   public Transform followTarget;
   public Transform sTealer;
   public float smoothTime = 0.3f;
   private Vector3 velocity = Vector3.zero;

   void LateUpdate()
   {
    Vector3 targetpPostion = followTarget.position;
    targetpPostion.z = transform.position.z;
    transform.position = Vector3.SmoothDamp(transform.position, targetpPostion, ref velocity, smoothTime);
   }
   public void SwitchCameraTargets(Transform newcameraTarget) 
   {
    followTarget = newcameraTarget;
   }
   void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.CompareTag("Stealer")) 
       {
          SwitchCameraTargets(sTealer);
       }
    }
} 
