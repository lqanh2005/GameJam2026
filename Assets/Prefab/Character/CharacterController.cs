using UnityEngine;

/// <summary>
/// Di chuyển A/D, Space = Jump. Dùng position trực tiếp, phù hợp với CheckLayerMask và world position.
/// A/D = Move | Space = Jump | Không input = Idle
/// </summary>
public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] bool useRigidbodyForJump = true;

    [Header("Bounds (tùy chọn)")]
    [SerializeField] bool clampPosition = false;
    [SerializeField] float minX = -10f;
    [SerializeField] float maxX = 10f;

    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    [Header("checkGr")]
    [SerializeField] Transform checkGr;
    [SerializeField] float distance=10f;
    [SerializeField] LayerMask Ground;

    const string SPEED_PARAM = "Speed";
    const string JUMP_PARAM = "Jump";

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimator();
    }

    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;

        pos.x += h * moveSpeed * Time.deltaTime;

        if (clampPosition)
            pos.x = Mathf.Clamp(pos.x, minX, maxX);

        transform.position = pos;

        if (spriteRenderer != null && Mathf.Abs(h) > 0.01f)
            spriteRenderer.flipX = h < 0;
    }

    void HandleJump()
    {
        if (!Input.GetButtonDown("Jump")) return;

        if (animator != null)
            animator.SetTrigger(JUMP_PARAM);

        if (useRigidbodyForJump && rb != null&&checkGround())
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void UpdateAnimator()
    {
        if (animator == null) return;

        float h = Input.GetAxisRaw("Horizontal");
        float speed = Mathf.Abs(h) > 0.01f ? 1f : 0f;
        animator.SetFloat(SPEED_PARAM, speed);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(checkGr.position,new Vector2(checkGr.position.x,checkGr.position.y-distance));
    }

    RaycastHit2D checkGround()=> Physics2D.Raycast(checkGr.position,Vector2.down,distance,Ground);
}
