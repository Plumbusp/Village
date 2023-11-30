using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItemChecker : IShopItemVisiter
{
    public bool isSelected;
    private PersistantData _persistantData;
    public SelectedItemChecker(PersistantData persistantData) => _persistantData = persistantData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatItem hatItem) => isSelected = (_persistantData.PlayerData.SelectedHat == hatItem.HatType);

    public void Visit(HairItem hairItem) => isSelected = (_persistantData.PlayerData.SelectedHair == hairItem.HairType);
}
