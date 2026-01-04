using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChapterLogoFader : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private float _fadeDuration = 1f;

    [SerializeField]
    private float _displayDuration = 2f;

    public void StartFade()
    {
        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        // Fade In
        float elapsedTime = 0f;
        Color color = _image.color;
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / _fadeDuration);
            _image.color = color;
            yield return null;
        }
        // Display
        yield return new WaitForSeconds(_displayDuration);
        // Fade Out
        elapsedTime = 0f;
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsedTime / _fadeDuration);
            _image.color = color;
            yield return null;
        }
    }
}
