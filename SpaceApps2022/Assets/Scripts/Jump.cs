using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
   

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public bool preJump = false;
    public PhysicsMaterial2D bounceMat, normalMat;

    private int direction = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMove();
        Flip();
        PlayerJump();
    }

    private void PlayerMove()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    private void PlayerJump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce += 0.5f;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.sharedMaterial = bounceMat;
            preJump = true;
        }
        else
        {
            preJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpForce >= 20.0f || Input.GetKeyDown(KeyCode.Space) == false && jumpForce >= 0.1f)
        {
            rb.velocity = Vector2.up * jumpForce;
            Invoke("ResetJump", 0.025f);
        }
        if (rb.velocity.y <= -1)
        {
            rb.sharedMaterial = normalMat;
        }
    }
    private void ResetJump()
    {
        jumpForce = 0.0f;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }
    /*void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius,whatIsGround);

        

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }*/
}