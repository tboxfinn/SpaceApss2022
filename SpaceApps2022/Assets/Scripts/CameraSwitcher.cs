using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraSwitcher : MonoBehaviour
{

    public GameObject room;
    public CinemachineVirtualCamera vcam;
    public bool isActive;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            isActive = true;
            Debug.Log("Player has been detected by: " + other.name);

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                isActive = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            vcam.Priority = 10;
        }
        else
        {
            vcam.Priority = 0;
        }
    }
}