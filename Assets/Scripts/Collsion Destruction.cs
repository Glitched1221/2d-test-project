
using UnityEngine;

public class CollsionDestruction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collsion detected");
            Destroy(gameObject);

        }
    }


}
   
    