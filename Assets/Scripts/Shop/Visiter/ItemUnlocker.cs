using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnlocker : IShopItemVisiter
{
    PersistantData _persistantData;
    public ItemUnlocker(PersistantData persistantData) => _persistantData = persistantData;
    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatItem hatItem) => _persistantData.PlayerData.OpenTheHat(hatItem.HatType);

    public void Visit(HairItem hairItem) => _persistantData.PlayerData.OpenTheHair(hairItem.HairType);
}
