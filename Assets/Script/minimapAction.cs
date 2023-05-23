using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapAction : MonoBehaviour
{
    private GameObject settingHolder;
    // Start is called before the first frame update
    void Start()
    {
        settingHolder = GameObject.FindGameObjectWithTag("Setting");
        if(settingHolder.GetComponent<Setting>().getmn() == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
