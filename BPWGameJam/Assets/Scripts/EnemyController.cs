using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private bool isTurned = true;
    public GameObject gameManager;

    [Header("Images")]
    public Sprite Broccoli;
    public Sprite Monster;
    public Sprite Belasting;
    public Sprite Reaper;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moving = new Vector2(moveSpeed, 0f) * Time.deltaTime;
        transform.Translate(moving);
        if (isTurned)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }

        string pState = gameManager.GetComponent<GameManager>().state;
        if (pState == "infant")
        {
            GetComponent<SpriteRenderer>().sprite = Broccoli;
        }
        if (pState == "child")
        {
            GetComponent<SpriteRenderer>().sprite = Monster;
        }
        if (pState == "adult")
        {
            GetComponent<SpriteRenderer>().sprite = Belasting;
        }
        if (pState == "senior")
        {
            GetComponent<SpriteRenderer>().sprite = Reaper;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Floor")
        {
            TurnAround();
        }
    }

    void TurnAround()
    {
        isTurned = !isTurned;
        Debug.Log("penis");
        rb.velocity = new Vector2(0f, 0f);
        //moveSpeed = moveSpeed * -1;
    }
}
