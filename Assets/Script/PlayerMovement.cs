using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Vector2 movement;
    public Vector2 lastMovement;
    // Update is called once per frame
    public Animator animator;
    public bool moving;
    
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        float horizontal  = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical);

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal !=0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (horizontal !=0 || vertical != 0)
        {
            lastMovement = new Vector2(horizontal , vertical).normalized;
            
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);

            
        }



    }
    

    
    void FixedUpdate()
    {
        rb.MovePosition (rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
