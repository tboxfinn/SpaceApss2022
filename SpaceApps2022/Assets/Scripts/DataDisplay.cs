using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDisplay : MonoBehaviour
{
    public DataItems data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    public void SpawnItems()
    {
        gameObject.SetActive(true);
    }
}
