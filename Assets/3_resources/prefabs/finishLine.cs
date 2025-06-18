using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2f;
    [SerializeField] private GameObject finishEffect; // 이펙트 프리팹을 에디터에서 할당
    private AudioSource audioSource; // 오디오 소스 컴포넌트
    private bool isfinished = false; // 게임이 끝났는지 여부
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&!isfinished)
        {
            isfinished = true;
            Debug.Log("2D Trigger 영역에 들어왔습니다: " + other.name);
            GameObject effect = Instantiate(finishEffect, other.transform.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            ps.Play();
            audioSource.Play(); // 오디오 재생
            Invoke("GameStop", 2f);
        }
    }
    private void GameStop()
    {
            GameManager.Instance.GameStop();

    }

    void ReloadScren()
    {
        SceneManager.LoadScene(0);
    }
}
