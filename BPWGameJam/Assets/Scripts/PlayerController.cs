using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    public float health = 100;
    public int Health { get; set; }
    public PlayerController(int health) { Health = health; }


    private Rigidbody2D rb;
    public Camera cam;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(hMove, vMove, 0).normalized;
        rb.velocity = movement * moveSpeed;
        //Camera follow
        Vector3 camPos = new Vector3(transform.position.x, 0, transform.position.z - 10f);
        cam.transform.position = camPos;
    }
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public virtual void GiveHealth(int healthUp)
    {
        if (health < 100)
        {
            health += healthUp;
        }
        if (health > 100)
        {
            health = 100;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
