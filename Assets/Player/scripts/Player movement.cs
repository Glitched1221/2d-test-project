using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//We will still need to tweak some of the settings.
public class RigidbodyMovement : MonoBehaviour
{
    public float boostlength;
    public float boostamount;
    public float dashcooldown;
    public float cooldowntimer;
    public Health hpcount;
    Rigidbody2D rb2d;
    private Vector3 moveDir;
    private Vector3 rollDir;
    public float moveSpeed = 5f;
    public float intailSpeed = 5f;
    public float runMiliplier;
    public float dashamount;
    public KeyCode dashkey = KeyCode.Space;
    public KeyCode rollkey = KeyCode.F;
    [SerializeField] private LayerMask dashLayerMask;
    
    private enum State{
        Normal,
        Rolling,
    }
    
    
    private bool isDashButtonDown;
  
    
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        
       
    }

    void Update()
    {
        cooldowntimer -= Time.deltaTime;

        //if (hpcount.HP > 0)
        {

        }

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

        moveDir = moveDirection;

      // Debug.Log("Rigidbody velocity" + moveSpeed); 

           if (Input.GetKeyDown(rollkey))
           {
            rollDir = moveDir;

           }

    
        if (Input.GetKeyDown(dashkey))
        {
            rb2d.MovePosition(transform.position + moveDir * dashamount);
            isDashButtonDown = true;
        }
    }

    // private void FixedUpdate()
    // {
    //     if (isDashButtonDown)
    //   {
    //         Vector3 dashpostion = transform.position + moveDir * dashamount;

            

    //         RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashamount, dashLayerMask);
    //         if (raycastHit2d.collider != null)
    //         {
    //             dashpostion = raycastHit2d.point;
    //             Debug.Log("hit");
    //         }
    //         rb2d.MovePosition(dashpostion);
    //         isDashButtonDown = false;
    //   }    
    // }

    private void FixedUpdate()
    {   
    if (isDashButtonDown)
    {
        
        Vector3 dashPosition = transform.position + moveDir * dashamount;

       
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, dashamount, dashLayerMask);

        if (raycastHit.collider != null)
        {
            dashPosition = raycastHit.point;
            Debug.Log("Hit an obstacle");
        }

        rb2d.MovePosition(dashPosition);

        isDashButtonDown = false;
    }
    }

 void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Speed"))
        {
           
            StartCoroutine(SpeedBoost());

        }
    }
        public IEnumerator SpeedBoost()
        {
           intailSpeed = intailSpeed + boostamount;
           yield return new WaitForSeconds(boostlength);
           intailSpeed = intailSpeed - boostamount;




        }

    // Character Controller in Unity 2D! (Move, Dodge, Dash) CodeMonkeyYoutube
   
     
}