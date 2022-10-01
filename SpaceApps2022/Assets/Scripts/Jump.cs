using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;

    [SerializeField] private GameManager gameManager;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    //PanelControl
    [SerializeField] float JumpForce;
    //imagespanel
    public static int index;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        isGrounded = true;

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.OnPanel == false)
        {
            rb.AddForce(Vector2.up * JumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InfoItem"))
        {
            gameManager.Display(collision.gameObject.GetComponent<DataDisplay>().data);

        }
    }


}