using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    void Start()
    {
        // ���� ���ӿ�����Ʈ�� �ִ� ParticleSystem, AudioSource ������Ʈ ��������
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other is CapsuleCollider2D)
        {
            GameManager.Instance.coin_num += 1;
            audioSource.Play();
            particleSystem.Play();
            Destroy(gameObject, 0.5f);
        }

    }
}
