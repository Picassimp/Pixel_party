using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private Animator anim;
    private float horizontal;
    private int jumpCount;

    private Vector3 checkPoint;
    private bool canmove;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem deathPartical;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        horizontal = 0;
        jumpCount = 0;
        checkPoint = transform.position;
        canmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(horizontal < 1)
            {
                horizontal += 0.02f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (horizontal > -1)
            {
                horizontal -= 0.02f;
            }
        }
        else
        {
            if (horizontal > 0.1f)
            {
                horizontal -= 0.02f;
            }
            else if (horizontal < -0.1f)
            {
                horizontal += 0.02f;
            }
            else
            {
                horizontal= 0;
            }
        }
        AnimationControl();
        Jump();
        skill();
    }

    private void FixedUpdate()
    {
        if (!canmove)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(horizontal * 8f, rb.velocity.y);
    }

    void AnimationControl()
    {
        if(horizontal > 0)
        {
            anim.SetBool("isRunning", true);
            GetComponent<Transform>().localScale = new Vector2(1f, 1f);
        }
        else if (horizontal < 0)
        {
            anim.SetBool("isRunning", true);
            GetComponent<Transform>().localScale = new Vector2(-1f, 1f);
        }
        else if (horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        jumpCount++;
        if (Input.GetKeyDown(KeyCode.Keypad0) && jumpCount <= 1)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 10f);  
        }
        else if (Input.GetKeyUp(KeyCode.Keypad0))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y/2);
        }

        if (!isGrounded())
        {
            anim.SetBool("isJumping", true);
        }
        else if(isGrounded())
        {
            jumpCount = 0;
            anim.SetBool("isJumping", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    public void respawn()
    {
        
        transform.position = checkPoint;
        Invoke("afterrespawn", 0.3f);
    }

    private void afterrespawn()
    {
        canmove= true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            canmove = false;
            anim.SetTrigger("hit");
            ParticleSystem ps = Instantiate(deathPartical, this.gameObject.transform.position, Quaternion.identity);
            ps.GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().playHit();
        }
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            if(collision.gameObject.transform.position.y > checkPoint.y)
            {
                checkPoint = collision.gameObject.transform.position;
            }
        }
    }
    private void skill()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GetComponent<AbiHolder>().useSkill();
        }
    }
}
