using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PreviewImage : MonoBehaviour
{
    private Image _image;
    private void OnEnable()
    {
        _image = GetComponent<Image>();
    }
    public void ShowPreview(ShopItemView shopItemView)
    {
        _image.sprite = shopItemView.Image.sprite;
    }
}
