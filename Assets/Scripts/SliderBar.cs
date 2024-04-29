using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI _labelTMP;

    [SerializeField]
    private Image _iconImage;

    [SerializeField]
    private TextMeshProUGUI _valueText;

    [Header("Provide values here")]
    [SerializeField]
    private string _labelText;
    [SerializeField]
    private Sprite _iconSprite;


    void Start()
    {
        _labelTMP.text = _labelText;
        _iconImage.sprite = _iconSprite;
    }

    public void SetMaxValue(int value)
    {
        _slider.maxValue = value;
        _slider.value = value;
        _fill.color = _gradient.Evaluate(1f);
        _valueText.text = value + "/" + _slider.maxValue;
    }

    public void SetCurrentValue(int value)
    {
        _slider.value = value;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        _valueText.text = value + "/" + _slider.maxValue;
    }
}
