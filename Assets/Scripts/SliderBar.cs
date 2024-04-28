using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Gradient _gradient;
    [SerializeField]
    private Image _fill;

    public void SetMaxValue(int value)
    {
        _slider.maxValue = value;
        _slider.value = value;

        _fill.color = _gradient.Evaluate(1f);
    }

    public void SetCurrentValue(int value)
    {
        _slider.value = value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
