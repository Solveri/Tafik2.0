using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask wall;
    [SerializeField] private Transform legs;
    [SerializeField] private Transform WallTouch;
    [SerializeField]float DownForce = 3f;
    [SerializeField] bool onGround;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool isWallSliding = false;
    int maxJump = 2;
    int jumpRem;
    Rigidbody2D rb;
    private float wallSlideSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpRem = maxJump;
    }

    // Update is called once per frame
    void Update()
    {
        IsonGround();
        iSTouchingWall();

    }
    private void FixedUpdate()
    {
        if (!onGround && isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-wallSlideSpeed,float.MaxValue));
            if (InputManager.instance.canJump && isWallSliding && jumpRem >0)
            {
                Jump();
            }
        }
        if (onGround)
        {
            isJumping = false;
        }
        if (InputManager.instance.Movement != Vector2.zero)
        {
            rb.velocity = new Vector2((rb.velocity.x + InputManager.instance.Movement.x * speed) * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (InputManager.instance.canJump)
        {
            if (onGround)
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
        isJumping = true;
        jumpRem--;


    }
    

    

    public void IsonGround()
    {
        //return Physics2D.CapsuleCast(legs.position,new Vector2(0.569552124f, 0.336158544f),CapsuleDirection2D.Horizontal,0,Vector2.down,0.1f,ground);
        onGround = Physics2D.OverlapCircle(legs.position,0.1f,ground);
        if (onGround)
        {
            jumpRem = maxJump;
        }
    }
    public void iSTouchingWall()
    {
        isWallSliding = Physics2D.OverlapCircle(WallTouch.position,0.1f,wall);
    }
}
