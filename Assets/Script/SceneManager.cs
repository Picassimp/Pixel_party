
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Startscene()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Start");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Startscene2()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Start");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map2", LoadSceneMode.Single);
    }

    public void Starttest()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("test", LoadSceneMode.Single);
    }

    public void retry()
    {
        Time.timeScale= 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        Time.timeScale = 1.0f;
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().stopBmg();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
