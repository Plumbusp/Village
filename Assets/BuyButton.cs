using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Button))]
public class BuyButton : MonoBehaviour
{
    public event Action Click;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _lockColor;
    [SerializeField] private Color _unlockColor;
    [SerializeField] private float _shakeDuration;
    [SerializeField, Range(0f, 1f)] private float _shakeStrength;
    private Button _button;
    private bool _isLock;
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
    public void UpdateText(string text) => _text.text = text;
    public void Lock()
    {
        _isLock = true;
        _button.image.color = _lockColor;
    }
    public void Unlock()
    {
        _isLock = false;
        _button.image.color = _unlockColor;
    }
    private void OnButtonClick()
    {
        if (_isLock)
        {
            transform.DOShakePosition(_shakeDuration, _shakeStrength);
            return;
        }
            Click?.Invoke();
    }
}
