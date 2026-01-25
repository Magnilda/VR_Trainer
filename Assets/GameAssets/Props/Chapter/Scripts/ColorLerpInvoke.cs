using UnityEngine;

public class ColorLerpInvoke : MonoBehaviour
{
    [SerializeField]
    private float _amountToDimBy = 0.5f;

    [SerializeField]
    private float _dimSpeedInSeconds = 3f;

    [SerializeField]
    private Color _colorToLerpTo_1;

    [SerializeField]
    private Color _colorToLerpTo_2;

    [SerializeField]
    private float _colorLerpSpeedInSeconds_1 = 1f;

    [SerializeField]
    private float _colorLerpSpeedInSeconds_2 = 5f;

    public void DimScreen()
    {
        Color targetColor = ColorLerper.Instance.DefaultColor * _amountToDimBy;
        ColorLerper.Instance.LerpToColor(_dimSpeedInSeconds, targetColor);
    }

    public void LerpToColor_1()
    {
        ColorLerper.Instance.LerpToColor(_colorLerpSpeedInSeconds_1, _colorToLerpTo_1);
    }

    public void LerpToColor_2()
    {
        ColorLerper.Instance.LerpToColor(_colorLerpSpeedInSeconds_2, _colorToLerpTo_2);
    }

    public void LerpToDefaultColor()
    {
        ColorLerper.Instance.LerpToDefaultColor(1f);
    }
}
