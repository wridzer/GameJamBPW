using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            playerController.isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            playerController.isGrounded = false;
        }
    }
}
