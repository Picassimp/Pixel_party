using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControl : MonoBehaviour
{
    private GameObject settingHolder;
    // Start is called before the first frame update
    void Start()
    {
        settingHolder = GameObject.FindGameObjectWithTag("Setting");
    }

    // Update is called once per frame
    public void changeMM()
    {
        settingHolder.GetComponent<Setting>().changedminiMap();
    }

    public bool getMM()
    {
        return settingHolder.GetComponent<Setting>().getmn();
    }
}
