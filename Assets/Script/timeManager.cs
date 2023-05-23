using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager.UI;

public class timeManager : MonoBehaviour
{
    float totalTime = 0; //30 minutes * 60 = 1800
    [SerializeField] private Text Text;
    public bool EnableTime = false;

    private void Update()
    {
        if (EnableTime == true)
        {
            totalTime += Time.deltaTime;
            UpdateLevelTimer(totalTime);
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        string mFH;
        string mSH;
        string sFH;
        string sSH;

        if (minutes.ToString().Length == 2)
        {
            
            mFH = (minutes.ToString()[0]).ToString();
            mSH = (minutes.ToString()[1]).ToString();
        }
        else
        {
            mFH = 0 + "";
            mSH = minutes.ToString();
        }

        if (seconds.ToString().Length == 2)
        {
            
            sFH = (seconds.ToString()[0]).ToString();
            sSH = (seconds.ToString()[1]).ToString();
        }
        else
        {
            sFH = 0 + "";
            sSH = seconds.ToString();
        }

        Text.text = mFH + "\n" + mSH + "\n:\n" + sFH + "\n" + sSH;

        if (totalTime <= 0f)
        {
            //Here is what you want to happen when the time is over
        }

    }

    public float total()
    {
        return totalTime;
    }
}