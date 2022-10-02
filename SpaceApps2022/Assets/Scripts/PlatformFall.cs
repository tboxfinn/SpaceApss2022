using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PLAYER"))
        {
            Invoke("DropPlatform", 1f);
            Destroy(gameObject, 4f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
