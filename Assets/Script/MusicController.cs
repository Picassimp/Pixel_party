using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource collect, bgm, hit;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void playCollect()
    {
        collect.Play();
    }

    public void playHit()
    {
        hit.Play();
    }

    public void playBmg()
    {
        if(bgm.isPlaying)
        {
            return;
        }
        else
        {
            bgm.Play();
        }
        
    }

    public void stopBmg()
    {
        bgm.Stop();
    }
}
