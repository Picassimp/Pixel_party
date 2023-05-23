using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class leaderboard : MonoBehaviour
{
    [SerializeField] private List<Text> names;
    [SerializeField] private List<Text> scores;
    private string key = "e133278d27475619ee45496b6207c5cdc4237c516b64f4f7df9f20a7605abac1";
    // Start is called before the first frame update
    private void Start()
    {
        GetLeaderBoard();
    }

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(key, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    
}
