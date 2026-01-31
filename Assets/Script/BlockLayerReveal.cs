using UnityEngine;

/// <summary>
/// Gắn lên mỗi block. Ẩn/hiện sprite và collider từ từ theo vị trí RevealLineController.
/// Layer 1: hiện khi block ở BÊN PHẢI line. Layer 2: hiện khi block ở BÊN TRÁI line.
/// </summary>
public class BlockLayerReveal : MonoBehaviour
{
    public enum BlockLayer { Layer1, Layer2 }

    [SerializeField] BlockLayer blockLayer = BlockLayer.Layer1;

    [Tooltip("Khoảng cách (đơn vị world) để block fade từ ẩn sang hiện. Càng lớn càng mượt.")]
    [SerializeField] float transitionWidth = 1.5f;

    [Tooltip("Alpha bao nhiêu trở lên thì bật collider (tránh player rơi xuyên khi đang fade).")]
    [Range(0.1f, 0.9f)]
    [SerializeField] float colliderThreshold = 0.5f;

    SpriteRenderer[] _sprites;
    Collider2D[] _colliders;
    Color[] _initialColors;

    void Awake()
    {
        _sprites = GetComponentsInChildren<SpriteRenderer>(true);
        _colliders = GetComponentsInChildren<Collider2D>(true);

        if (_sprites != null)
        {
            _initialColors = new Color[_sprites.Length];
            for (int i = 0; i < _sprites.Length; i++)
                if (_sprites[i]) _initialColors[i] = _sprites[i].color;
        }
    }

    void Update()
    {
        if (_sprites == null || _colliders == null) return;

        float lineX = RevealLineController.LinePositionX;
        float myX = transform.position.x;
        float dist = myX - lineX;

        // Layer 1: visibility = 1 khi xa line về bên phải, 0 khi xa về bên trái
        // Layer 2: ngược lại
        float raw = blockLayer == BlockLayer.Layer1 ? dist : -dist;
        float visibility = Mathf.Clamp01(raw / Mathf.Max(0.01f, transitionWidth) * 0.5f + 0.5f);

        // Sprite: fade alpha
        for (int i = 0; i < _sprites.Length; i++)
        {
            if (_sprites[i] == null || i >= _initialColors.Length) continue;
            Color c = _initialColors[i];
            _sprites[i].color = new Color(c.r, c.g, c.b, c.a * visibility);
            _sprites[i].enabled = visibility > 0.001f;
        }

        // Collider: bật khi đủ "đặc" để player đứng được
        bool colEnabled = visibility >= colliderThreshold;
        foreach (var c in _colliders)
            if (c) c.enabled = colEnabled;
    }
}
