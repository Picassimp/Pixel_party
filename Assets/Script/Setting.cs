using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public bool minimap;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        minimap= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changedminiMap()
    {
        minimap = !minimap;
    }

    public bool getmn()
    {
        return minimap;
    }
}
