using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameStart : MonoBehaviour
{
    [SerializeField] private Text fps1;
    private int targetFrameRate = 60;
    private float deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().playBmg();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fps1.text = Mathf.Ceil(fps).ToString();
    }
}
