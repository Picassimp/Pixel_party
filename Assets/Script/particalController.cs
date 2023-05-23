using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particalController : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        ps = GetComponent<ParticleSystem>();

        var main = ps.main;
        main.loop = false;
    }
}
