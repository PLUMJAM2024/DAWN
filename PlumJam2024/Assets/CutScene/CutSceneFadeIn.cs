using System.Collections;
using UnityEngine;

public class CutSceneFadeIn : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isFadein = true;

    private void Awake()
    {
        // SpriteRenderer 컴포넌트를 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 시작 시 완전히 투명하게 설정
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.color = color;
    }

    private IEnumerator Start()
    {

        if (isFadein)
            yield return TweenFade(1f, 0.5f);
        else
        {
            var color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
            yield return null;
        }
    }

    private IEnumerator TweenFade(float endValue, float duration)
    {
        var color = spriteRenderer.color;
        var startAlpha = color.a;
        var t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            color.a = Mathf.Lerp(startAlpha, endValue, t);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endValue;
        spriteRenderer.color = color;
    }
}
