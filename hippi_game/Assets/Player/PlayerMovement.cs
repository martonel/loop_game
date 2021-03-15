using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection.Emit;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private float moveInput;
    public float Speed = 20.0f;
    public float JumpForce;   //10
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float chechRadius;
    public LayerMask whatIsGround;
    private bool facingRight = true;
    private int extraJump;
    public int extraJumpValue = 2;

    public bool WallSlide;
    //wallslide
    private bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;  //8
    private bool wallJumping;       //
    public float xWallForce;        //30
    public float yWallForce;        //14
    public float wallJumpTime;      //0.15








    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        extraJump = extraJumpValue;
        //transform.position = startPos.initialVector;
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chechRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        if (moveInput > 0)
        {
            anim.SetBool("isRunning", true);
            if (facingRight == false)
            {
                Flip();
            }
        }
        else if (moveInput < 0)
        {
            anim.SetBool("isRunning", true);
            if (facingRight == true)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                extraJump = extraJumpValue;
            }
            if (extraJump != 0)
            {
                //anim.SetTrigger("Jump");
                rb.velocity = Vector2.up * JumpForce;
                extraJump--;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * 5.0f;
        }
        if (WallSlide == true)
        {
            WallSlider();
        }



    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void WallSlider()
    {
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, chechRadius, whatIsGround);
        if (isTouchingFront == true && isGrounded == false && moveInput != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding == true)
        {

            rb.velocity = Vector3.down * wallSlidingSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            extraJump = extraJumpValue;
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
            if (wallSliding == false)
            {
                wallJumping = false;
            }
        }
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

}