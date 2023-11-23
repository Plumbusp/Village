using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _ItemPrefab;
    public ShopItemView Get(ShopItem item, Transform parent)
    {
        ShopItemView instance = Instantiate(_ItemPrefab, parent);
        instance.Initialize(item);
        return instance; 
    }
} 
