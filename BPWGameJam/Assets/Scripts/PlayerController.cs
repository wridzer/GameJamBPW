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
    [SerializeField] private float jumpForce;
    [SerializeField] private float smoothCamera = 2.5f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private Transform cameraTransform;
    [HideInInspector] public bool isGrounded;
    int jumpCount;
    float startCameraY;
    float jumpCoolDown;
    LayerMask groundLayer;

    public GameObject gameManager;


    [Header("Images")]
    public Sprite infant;
    public Sprite child;
    public Sprite adult;
    public Sprite senior;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startCameraY = cameraTransform.position.y;
        groundLayer = LayerMask.GetMask("GroundLayer");
    }

    // Update is called once per frame
    void Update()
    {
        // //Move
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0f);
        rb.velocity = movement * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        //Jump
        Jump();
        //Camera follow
        Vector3 cameraPos = new Vector3(Camera.main.transform.position.x, startCameraY, cameraTransform.position.z);
        Vector3 newCameraPos = new Vector3(cameraTransform.position.x, startCameraY, cameraTransform.position.z);
        Camera.main.transform.position = Vector3.Lerp(cameraPos, newCameraPos, Time.fixedDeltaTime * smoothCamera);



        string pState = gameManager.GetComponent<GameManager>().state;
        if (pState == "infant")
        {
            GetComponent<SpriteRenderer>().sprite = infant;
        }
        if (pState == "child")
        {
            GetComponent<SpriteRenderer>().sprite = child;
        }
        if (pState == "adult")
        {
            GetComponent<SpriteRenderer>().sprite = adult;
        }
        if (pState == "senior")
        {
            GetComponent<SpriteRenderer>().sprite = senior;
        }
    }
    void Jump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
