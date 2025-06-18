using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2f;
    [SerializeField] private GameObject finishEffect; // ����Ʈ �������� �����Ϳ��� �Ҵ�
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ
    private bool isfinished = false; // ������ �������� ����
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
            Debug.Log("2D Trigger ������ ���Խ��ϴ�: " + other.name);
            GameObject effect = Instantiate(finishEffect, other.transform.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            ps.Play();
            audioSource.Play(); // ����� ���
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
