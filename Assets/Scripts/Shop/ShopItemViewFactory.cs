using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _hairPrefab;
    [SerializeField] private ShopItemView _hatPrefab;
    private ShopItemVisiter _shopItemVisiter;
    private void Awake()
    {
        _shopItemVisiter = new ShopItemVisiter(_hatPrefab, _hairPrefab);
    }
    public ShopItemView Get(ShopItem item, Transform parent)
    {
        _shopItemVisiter = new ShopItemVisiter(_hatPrefab, _hairPrefab);
        _shopItemVisiter.Visit(item);
        ShopItemView instance = Instantiate(_shopItemVisiter.Prefab, parent);
        instance.Initialize(item);
        return instance; 
    }
    private class ShopItemVisiter : IShopItemVisiter
    {
        public ShopItemView Prefab; // public variable to access
        private ShopItemView _hairPrefab;
        private ShopItemView _hatPrefab;
        public ShopItemVisiter(ShopItemView hatPrefab, ShopItemView hairPrefab)
        {
            _hairPrefab = hatPrefab;
            _hatPrefab = hairPrefab;
        }
        public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(HatItem hatItem) => Prefab = _hatPrefab;

        public void Visit(HairItem hairItem) => Prefab = _hairPrefab;
    }
}
