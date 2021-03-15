using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    public float health = 100;
    public int Health { get; set; }
    public PlayerController(int health) { Health = health; }


    private Rigidbody rb;
    public GameObject dunGen, weapon;
    public Camera cam;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(hMove, 0, vMove).normalized;
        rb.velocity = movement * moveSpeed;
        //Rotate
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mouseOnScreen.y - positionOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle - 90, 0f));
        //Camera follow
        Vector3 camPos = new Vector3(transform.position.x, 5, transform.position.z - 7.5f);
        cam.transform.position = camPos;
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("stabbo");
            weapon.SetActive(true);
        }
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
