using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PLAYER"))
        {
            Invoke("DropPlatform", 2.5f);

        }
    }

    void DropPlatform()
    {
        //rb.isKinematic = false;
        sr.color = new Color(1, 1, 1, 0.0f);
        bc.enabled = false;
        Invoke("RespawnPlatform", 2.5f);
    }
    private void RespawnPlatform()
    {
        //rb.isKinematic = true;
        sr.color = new Color(1, 1, 1, 1.0f);
        bc.enabled = true;
    }
}
