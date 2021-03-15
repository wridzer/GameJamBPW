using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] Transform respawnPos;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            FindObjectOfType<PlayerController>().transform.position = respawnPos.position;
        }
    }
}
