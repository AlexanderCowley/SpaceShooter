using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObjectFader : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Color _defaultColor;
    Color _fadedColor;

    void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        Color _fadedColor = new Color(_spriteRenderer.color.r,
            _spriteRenderer.color.g,
            _spriteRenderer.color.b, 0.75f);
    }

    [ContextMenu("Fade")]
    public void Fade()
    {
        Init();
        _spriteRenderer.color = _fadedColor;
    }

    [ContextMenu("FadeOut")]
    public void FadeOut() => _spriteRenderer.color = _defaultColor;
}