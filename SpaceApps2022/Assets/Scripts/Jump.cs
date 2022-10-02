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

    private float direction = 1;
    [SerializeField] private float limite;


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
        if (isGrounded && !preJump)
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

        direction = Input.GetAxisRaw("Horizontal");

        if (isGrounded == true && preJump)
        {
            jumpForce += 12f * Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.sharedMaterial = bounceMat;

        }
        if (Input.GetKey(KeyCode.Space) && jumpForce < limite)
        {

            preJump = true;
        }
        else if (preJump || jumpForce >= limite)
        {
            preJump = false;

            rb.AddForce(new Vector2(direction, 1) * jumpForce, ForceMode2D.Impulse);

        }

        if (rb.velocity.y <= -1)
        {


            rb.sharedMaterial = normalMat;
        }
        if (rb.velocity.y >= 1)
        {
            jumpForce = 0;
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

    
}