using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y+1f, -10f);
        if (player.transform.position.x <= -3.5)
        {
            target = new Vector3(-3.5f, player.transform.position.y + 1f, -10f);
        }
        else if (player.transform.position.x >= 9.5)
        {
            target = new Vector3(9.5f, player.transform.position.y + 1f, -10f);
        }
        this.transform.position = Vector3.MoveTowards(transform.position, target, 5f);
    }
}
