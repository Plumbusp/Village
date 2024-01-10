using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopItemView> Click;

    private Image _backgroundImage;
    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightBackground;
    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockMask;
    [SerializeField] private intValueView _priceView;
    [SerializeField] private GameObject _selectedText;

    public ShopItem Item { get; private set; }
    public bool IsLock { get; private set; }
    public int Price => Item.Price;
    public Image Image => _contentImage;
    public void Initialize(ShopItem item)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standardBackground;

        Item = item;
        _contentImage.sprite = item.Image;
        _priceView.Show(Price);
    }
    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    public void Lock()
    {
        IsLock = true;
        _lockMask.gameObject.SetActive(IsLock);
        _priceView.Show(Price);
    }
    public void Unlock()
    {
        IsLock = false;
        _lockMask.gameObject.SetActive(IsLock);
        _priceView.Hide();
    }
    public void Highlighte() => _backgroundImage.sprite = _highlightBackground;
    public void UnHighlighte() => _backgroundImage.sprite = _standardBackground;
    public void Select() => _selectedText.gameObject.SetActive(true); // Visually somehow show, that the item is selected
    public void UnSelected() => _selectedText.gameObject.SetActive(false); 
}
