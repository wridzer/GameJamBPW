using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.timePassed = 0;
        Destroy(gameObject);
    }

}
