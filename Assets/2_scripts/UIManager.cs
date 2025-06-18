using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Text timeText;
    public Text surfacespeedText;
    public Text carspeedText;
    public Text currunttime;
    public Text fasttime;
    public Text cointext;
    public GameObject panel; // GameObject·Î º¯°æ

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTimeText(string time)
    {
        timeText.text = time;
    }
    public void UpdateSurfaceText(string speed)
    {
        surfacespeedText.text = speed;
    }
    public void UpdateCarSpeedText(string speed)
    {
        carspeedText.text = speed;
    }
    public void UpdateCurrentTimeText(string time)
    {
        currunttime.text = time;
    }
    public void UpdateFastTimeText(string time)
    {
        fasttime.text = time;
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
    public void RestartGame()
    {
        GameManager.Instance.GameRestart();
    }
    private void Update()
    {
        cointext.text= "Coin: " + GameManager.Instance.coin_num.ToString();
    }
}