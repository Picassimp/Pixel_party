using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private Material material;
    private float fade = 1f;
    private bool isFading = false;
    // Start is called before the first frame update
    private void Start()
    {
        material= GetComponent<SpriteRenderer>().material;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ScoreManager>().collectApple();
            coll();
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<ScoreManager>().collectApple();
            coll();
        }
    }


    void coll()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        isFading= true;
        //gameObject.SetActive(false);
        GetComponent<CircleCollider2D>().enabled = false;
        Invoke("respawn", 10f);
    }

    private void FixedUpdate()
    {
        if(isFading)
        {
            fade -= 0.04f;
            material.SetFloat("_Fade", fade);
        }
    }

    void respawn()
    {
        isFading= false;
        fade = 1f;
        material.SetFloat("_Fade", fade);
        //gameObject.SetActive(true);
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
