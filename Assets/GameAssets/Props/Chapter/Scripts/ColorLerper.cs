using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerper : MonoBehaviour
{
    public static ColorLerper Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField]
    private Image _imageToLerp;

    [SerializeField]
    private Color _defaultColor;
    public Color DefaultColor => _defaultColor;

    public void LerpToColor(float timeInSeconds, Color targetColor)
    {
        StartCoroutine(LerpColorCoroutine(timeInSeconds, targetColor));
    }

    private IEnumerator LerpColorCoroutine(float timeInSeconds, Color targetColor)
    {
        Color initialColor = _imageToLerp.color;
        float elapsedTime = 0f;
        while (elapsedTime < timeInSeconds)
        {
            _imageToLerp.color = Color.Lerp(initialColor, targetColor, elapsedTime / timeInSeconds);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _imageToLerp.color = targetColor;
    }

    public void LerpToDefaultColor(float timeInSeconds)
    {
        LerpToColor(timeInSeconds, _defaultColor);
    }
}
