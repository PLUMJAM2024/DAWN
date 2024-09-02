using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

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

        var wfs = new WaitForSeconds(0.1f);

        for (var i = 0; i < 10; i++)
        {
            yield return TweenFade(0.5f, 0.2f);
            yield return wfs;
            yield return TweenFade(1f, 0.2f);
            yield return wfs;
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
