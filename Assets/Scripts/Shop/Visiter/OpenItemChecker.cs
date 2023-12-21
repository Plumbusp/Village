using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenItemChecker : IShopItemVisiter
{
    public bool isOpened;
    private PersistantData _persistantData;
    public OpenItemChecker(PersistantData persistantData) => _persistantData = persistantData;
    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatItem hatItem) => isOpened = _persistantData.PlayerData.OpenHats.Contains(hatItem.HatType);

    public void Visit(HairItem hairItem) => isOpened = _persistantData.PlayerData.OpenHairs.Contains(hairItem.HairType);
}
