using System.Collections;
using System.Collections.Generic;

using UnityEngine;

       //We will still need to tweak some of the settings.
public class RigidbodyMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    public float intailSpeed = 5f;
    public float runMiliplier;
    
    private bool isDashButtonDown;
    
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("Player is spawned");
       
    }

    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)
        animator.SetFloat("InputY", moveInputY);
        animator.SetFloat("InputX", moveInputX);
        moveSpeed = Input.GetKey(KeyCode.LeftShift)? intailSpeed* runMiliplier : intailSpeed;

        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;

      // Debug.Log("Rigidbody velocity" + moveSpeed); 

       
    }
   
     
}