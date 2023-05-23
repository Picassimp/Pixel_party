using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneClick : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, mapPanel, lbPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openPanelMap()
    {
        mapPanel.SetActive(true);
    }

    public void closePanelMap()
    {
        mapPanel.SetActive(false);
    }

    public void openPanelMenu()
    {
        menuPanel.SetActive(true);
    }

    public void closePanelMenu()
    {
        menuPanel.SetActive(false);
    }

    public void openPanelLB()
    {
        lbPanel.SetActive(true);
    }

    public void closePanelLB()
    {
        lbPanel.SetActive(false);
    }
}
