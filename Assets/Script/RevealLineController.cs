using UnityEngine;

/// <summary>
/// Điều khiển đường line dọc di chuyển từ trái sang phải.
/// Logic: Bên TRÁI line = Layer 2 hiện / Layer 1 ẩn. Bên PHẢI line = Layer 1 hiện / Layer 2 ẩn.
/// </summary>
public class RevealLineController : MonoBehaviour
{
    [Header("Chuyển động")]
    [SerializeField] float speed = 3f;
    [SerializeField] float leftBound = -15f;
    [SerializeField] float rightBound = 15f;
    [SerializeField] bool loop = true;

    /// <summary>Vị trí X hiện tại của line (world space). Các BlockLayerReveal dùng giá trị này.</summary>
    public static float LinePositionX { get; private set; }

    void Start()
    {
        LinePositionX = transform.position.x;
    }

    void Update()
    {
        float newX = transform.position.x + speed * Time.deltaTime;
        if (newX > rightBound)
        {
            if (loop)
                newX = leftBound;
            else
                newX = rightBound;
        }
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        LinePositionX = transform.position.x;
    }

    void OnDrawGizmos()
    {
        Vector3 pos = Application.isPlaying ? new Vector3(LinePositionX, transform.position.y, 0) : transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(pos + Vector3.up * 20f, pos + Vector3.down * 20f);
    }
}
