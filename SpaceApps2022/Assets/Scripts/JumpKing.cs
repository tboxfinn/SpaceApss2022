using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKing : MonoBehaviour
{
    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    public Animator animator;
    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");
        
        //esto es para rotar dependiendo de si le doy izquierda o derecha, me lo enseño drolejan
        if (moveInput > 0)
        {
            transform.localScale = new Vector2(1, 1);

        }else if (moveInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        //aqui es como me muevo derecha o izq
        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);     
        }
        //esto checa que el jugador este en el suelo
        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        //no se que hace pero me hace rebotar creo
        if (jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        // carga el jumpvalue mientras dejes el espacio precionado y estes en ground
        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.11f;
            animator.SetBool("IsCharging", true);

        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y); //define la velocidad de y para el salto
            animator.SetBool("IsCharging", true);
        }

        //cuando llega a 20f el jump value y esta en el suelo saltas
        if (jumpValue >= 20f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
            jumpSoundEffect.Play();

        }

        //si sueltas el espacio saltas
        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
                jumpSoundEffect.Play();
            }
            canJump = true;
            animator.SetBool("IsCharging", false);
            
        }
    }

    void ResetJump()  
    {
        canJump = false;
        jumpValue = 0;
        animator.SetBool("IsCharging", false);
    }

    void OnDrawGizmosSelected() //para chequear que ground este tocando el pisos
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f), new Vector2(0.9f, 0.2f));
    }


}
