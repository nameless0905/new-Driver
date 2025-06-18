using UnityEngine;

public class MyCarController : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    private bool onGround = false;
    private bool onLoad = false; // load 태그 판정용

    public float jumpForce = 7f;
    public float airRotateSpeed = 200f; // 공중 회전 속도
    private AudioSource AS;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = false; // Rigidbody2D의 freezeRotation 해제
        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation; // Z축 회전 제한 해제
        AS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<SurfaceEffector2D>(out var effector))
        {
            onGround = true;
            surfaceEffector2D = effector;

            Debug.Log($"Collision with {collision.gameObject.name} detected. " +
                $"Effector: {surfaceEffector2D.speed}");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // SurfaceEffector2D가 붙은 오브젝트에서 떨어질 때 onGround를 false로 설정
        {
            onGround = false;
            surfaceEffector2D = null;
            Debug.Log($"Exit from {collision.gameObject.name}. onGround = false");
        }
    }

    private void Update()
    {
        if (surfaceEffector2D == null) return;
        if (onGround) { AS.Play(); }
        else { AS.Stop(); }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onGround)
        {
            surfaceEffector2D.speed = 12f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            surfaceEffector2D.speed = 0f;
        }
        UIManager.Instance.UpdateSurfaceText($"surface Speed : {surfaceEffector2D.speed:F1}");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }
        UIManager.Instance.UpdateCarSpeedText($"Car Speed : {rb.linearVelocity.magnitude:F1}");

    }

    private void Jump()
    {
        onGround = false;

        if (rb == null) return;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (!onGround)
        {
            float rotateInput = 0f;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                rotateInput = 1f;
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                rotateInput = 0f;
            if (Input.GetKeyDown(KeyCode.RightArrow))
                rotateInput = -1f;
            if (Input.GetKeyUp(KeyCode.RightArrow))
                rotateInput = 0f;

            if (rotateInput != 0f)
            {
                rb.MoveRotation(rb.rotation + rotateInput * airRotateSpeed * Time.deltaTime);
            }
        }
        
    }
}
