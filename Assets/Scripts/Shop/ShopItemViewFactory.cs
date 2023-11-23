using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItemViewFactory", menuName = "Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _hatPrefab;
    [SerializeField] private ShopItemView _hairPrefab;
    public ShopItemView Get(ShopItem item, Transform parent)
    {
        ShopItemView instance = null;
        switch (item)
        {
            case HatItem hatItem:
                instance = Instantiate(_hatPrefab, parent);
                break;
            case HairItem hairItem:
                instance = Instantiate(_hairPrefab, parent);
                break;
            default:
                Debug.LogWarning("The type does not exist");
                break;
        }
        instance.Initialize(item);
        return instance; 
    }
} 
