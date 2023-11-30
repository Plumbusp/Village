 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    private List<ShopItemView> _shopItems = new List<ShopItemView>(); // All currently showen shop Items

    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;
    IEnumerable<ShopItem> test;
    [SerializeField] private Transform _parent; // the parent under which items will spawn

    public void Show(IEnumerable<ShopItem> shopItems)
    {
        Clear();
        foreach(ShopItem item in shopItems)
        {
            ShopItemView instance = _shopItemViewFactory.Get(item, _parent);
            _shopItems.Add(instance);
            instance.Click += OnShopItemClicked;
            instance.UnHighlighted();

        }

    }
    private void Clear()
    {
        foreach(ShopItemView item in _shopItems)
        {
            item.Click -= OnShopItemClicked;
            Destroy(item.gameObject);
        }
        _shopItems.Clear();
    }
    private void OnShopItemClicked(ShopItemView shopItemView)
    {
        Debug.Log("Clicked");
    }
}
