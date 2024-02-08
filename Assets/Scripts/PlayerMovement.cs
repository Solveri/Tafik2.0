using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform legs;
    [SerializeField]float DownForce = 3f;
    [SerializeField]bool onGround;
    int maxJump = 2;
    int jumpRem;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpRem = maxJump;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsonGround()) {
            onGround = true;
            jumpRem = maxJump;

        }
        else
        {
            onGround = false;
        }

    }
    private void FixedUpdate()
    {
        if (InputManager.instance.Movement != Vector2.zero)
        {
            rb.velocity = new Vector2((rb.velocity.x + InputManager.instance.Movement.x * speed) * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (InputManager.instance.canJump && jumpRem > 0)
        {
            if (onGround)
            {
                Jump();


            }
            else
            {
                Jump();
            }

        }
        if (!onGround)
        {
            rb.AddForce(Vector2.down*DownForce*Time.deltaTime);
           
        }



    }
    void Jump()
    {

        rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y + JumpForce)) * Time.deltaTime;
        jumpRem--;


    }
    

    

    public RaycastHit2D IsonGround()
    {
        return Physics2D.CapsuleCast(legs.position,new Vector2(0.569552124f, 0.336158544f),CapsuleDirection2D.Horizontal,0,Vector2.down,0.1f,ground);
    }
}