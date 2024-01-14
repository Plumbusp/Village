using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public event Action<ShopItemView>OnItemViewClicked;
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;
    [SerializeField] private Transform _parent; // the parent under which items will spawn
    private List<ShopItemView> _shopItems = new List<ShopItemView>(); // All currently showen shop Items
    private OpenItemChecker _openItemChecker;
    private SelectedItemChecker _selectedItemChecker;
    public void Initialize(OpenItemChecker openItemChecker, SelectedItemChecker selectedItemChecker)
    {
        _openItemChecker = openItemChecker;
        _selectedItemChecker = selectedItemChecker;
    }
    public void Show(IEnumerable<ShopItem> shopItems)
    {
        Clear();
        foreach(ShopItem shopItem in shopItems)
        {
            ShopItemView instance = _shopItemViewFactory.Get(shopItem, _parent);
            _shopItems.Add(instance);
            instance.Click += OnItemViewClick;
            instance.UnHighlighte();
            instance.UnSelected();
            _openItemChecker.Visit(shopItem);
            if (_openItemChecker.isOpened)
            {
                _selectedItemChecker.Visit(shopItem);
                if (_selectedItemChecker.isSelected)
                {
                    OnItemViewClick(instance);  //Visually selceting item if it is Bought And Selected
                    instance.Highlighte();       
                    instance.Select();
                } 
                instance.Unlock();  
            }
            else
            {
                instance.Lock();
            }
        }
    }
    private void Clear()
    {
        foreach(ShopItemView item in _shopItems)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }
        _shopItems.Clear();
    }
    private void OnItemViewClick(ShopItemView shopItemView)
    {
        Highlight(shopItemView);
        OnItemViewClicked?.Invoke(shopItemView);
    }
    public void Highlight(ShopItemView shopItemView)  //! Visually ! hightlighting the view item
    {
        foreach(var itemView in _shopItems)
        {
            itemView.UnHighlighte();
        }
        shopItemView.Highlighte();
    }
    public void Select(ShopItemView shopItemView) //! Visually ! selecting the view item (the method Select() in ShopItemView Enables the little "selected" text on the view item )
    {
        foreach (var itemView in _shopItems)
        {
            itemView.UnSelected();
        }
        shopItemView.Select();
    }
}
