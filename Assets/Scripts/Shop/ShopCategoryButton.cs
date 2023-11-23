using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class ShopCategoryButton : MonoBehaviour
{
    public event Action Click;
    [SerializeField] private Image _image;
    [SerializeField] private Color _unselectedColor;
    [SerializeField] private Color _selectedColor;
    private Button _button;
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        
    }
    public void Selected() => _image.color = _selectedColor;
    public void UnSelected() => _image.color = _unselectedColor;
    private void OnClick() => Click.Invoke();
}
