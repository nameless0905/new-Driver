using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.elapsedTime = 0f;
        GameManager.Instance.coin_num = 0;
    }
}
