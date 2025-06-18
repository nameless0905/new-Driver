using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    void Start()
    {
        // 같은 게임오브젝트에 있는 ParticleSystem, AudioSource 컴포넌트 가져오기
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
