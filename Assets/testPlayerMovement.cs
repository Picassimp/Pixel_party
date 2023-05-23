using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    private float horizontal;
    private bool isAired;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        horizontal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0 )
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        Jump();
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * 8f, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAired)
        {
            isAired= true;
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }

        if(isGrounded() && rb.velocity.y < 0)
        {
            isAired= false;
        }
    }

    void Flip()
    {
        if (horizontal > 0)
        {
            GetComponent<Transform>().localScale = new Vector2(1f, 1f);
        }
        else if (horizontal < 0)
        {
            GetComponent<Transform>().localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
        if (collision.gameObject.CompareTag("weak"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
