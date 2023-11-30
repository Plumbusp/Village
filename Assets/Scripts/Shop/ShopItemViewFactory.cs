using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _hairPrefab;
    [SerializeField] private ShopItemView _hatPrefab;
    private ShopItemVisiter _shopItemVisiter = new ShopItemVisiter(_hatPrefab, _hairPrefab);
    public ShopItemView Get(ShopItem item, Transform parent)
    {
        ShopItemView instance = null;
         
        instance.Initialize(item);
        return instance; 
    }
    private class ShopItemVisiter : IShopItemVisiter
    {
        public ShopItemView prefab;
        private ShopItemView _hairPrefab;
        private ShopItemView _hatPrefab;
        ShopItemVisiter(ShopItemView hatPrefab, ShopItemView hairPrefab)
        {
            _hairPrefab = hatPrefab;
            _hatPrefab = hairPrefab;
        }
        public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

        public void Visit(HatItem hatItem) => prefab = _hatPrefab;

        public void Visit(HairItem hairItem) => prefab = _hairPrefab;
    }
}
