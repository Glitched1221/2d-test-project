
using UnityEngine;

public class Respawn : MonoBehaviour
{
   public GameObject Respawnpoint;
   public GameObject Player;

   void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = Respawnpoint.transform.position;
        }
    
        

   }
 
}
