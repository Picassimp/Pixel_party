using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minimapButt : MonoBehaviour
{
    [SerializeField] private bool status;
    private GameObject settingHolder;
    // Start is called before the first frame update
    void Start()
    {
        settingHolder = GameObject.FindGameObjectWithTag("Setting");
        if (status == settingHolder.GetComponent<Setting>().getmn())
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(status == settingHolder.GetComponent<Setting>().getmn())
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
