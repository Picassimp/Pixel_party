using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Dan.Main;

public class winning : MonoBehaviour
{
    [SerializeField] private GameObject notifi;
    [SerializeField] private GameObject notifiPlayer1;
    [SerializeField] private GameObject notifiPlayer2;
    private string _key = "e133278d27475619ee45496b6207c5cdc4237c516b64f4f7df9f20a7605abac1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notifi.SetActive(true);
            notifiPlayer1.SetActive(true);
            SetLeaderboardEntry("Player 1 " + System.DateTime.UtcNow);
            Time.timeScale=0f;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            notifi.SetActive(true);
            notifiPlayer2.SetActive(true);
            SetLeaderboardEntry("Player 2 " + System.DateTime.UtcNow);
            Time.timeScale = 0f;
        }
    }

    public UnityEvent<string, int> submitScoreEvent;

    private void Submitscore(string winner)
    {
        int finishTime = (int) GameObject.FindGameObjectWithTag("time").GetComponent<timeManager>().total();
        submitScoreEvent.Invoke(winner, finishTime);
    }

    public void SetLeaderboardEntry(string username)
    {
        int finishTime = (int)GameObject.FindGameObjectWithTag("time").GetComponent<timeManager>().total();
        LeaderboardCreator.UploadNewEntry(_key, username, finishTime, ((msg) =>
        {

        }));
    }

    private void Callback(bool success)
    {
        if (success)
        {
            
        }
    }
}
