using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float elapsedTime = 0f;
    private float fatestTime = float.MaxValue;
    public int coin_num = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        UIManager.Instance.UpdateTimeText(FormatElapsedTime(elapsedTime));
    }

    public void GameStop()
    {
        Time.timeScale = 0f;


        if (elapsedTime < fatestTime)
        {
            fatestTime = elapsedTime;
            Debug.Log("New fastest time: " + FormatElapsedTime(fatestTime));
        }
        UIManager.Instance.UpdateFastTimeText("Current Time: " + FormatElapsedTime(elapsedTime));
        UIManager.Instance.UpdateCurrentTimeText("Fastest Time: " + FormatElapsedTime(fatestTime));

        elapsedTime = 0f;

        UIManager.Instance.ShowPanel();
    }
    public void GameRestart()
    {
        Time.timeScale = 1f;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
        elapsedTime = 0f;
        
        UIManager.Instance.HidePanel();
        GameManager.Instance.coin_num = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private string FormatElapsedTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        int milliseconds = (int)((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
