using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int apple;
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectApple()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().playCollect();
        apple++;
        if(apple == 5) {
            apple = 0;
            GetComponent<AbiHolder>().addSkill();
        }
        text.text = apple + "";
    }
}
