using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private float distance;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        //up = false;
        distance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 0)
        {
            up = false;
        }
        else if(transform.position.y <= -0.8f)
        {
            up = true;
        }

        if (!up)
        {
            distance -= 0.005f;
            
        }
        else
        {
            distance += 0.005f;
        }
        transform.position = new Vector3(0, distance, 0);
        
    }
}
