using System;
using System.Runtime.Remoting.Messaging;

public class ItemSelector : IShopItemVisiter
{
    public event Action<HatItem> OnHatItemSelected;  
    public event Action<HairItem> OnHairItemSelected;

    private PersistantData _persistantData;
    public ItemSelector(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }
    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatItem hatItem)
    {
        _persistantData.PlayerData.SelectedHat = hatItem.HatType;
        if(_persistantData.PlayerData.SelectedHat == hatItem.HatType)
        {
            OnHatItemSelected?.Invoke(hatItem);
        }
    }

    public void Visit(HairItem hairItem)
    {
       _persistantData.PlayerData.SelectedHair = hairItem.HairType;
        if (_persistantData.PlayerData.SelectedHair == hairItem.HairType)
        {
            OnHairItemSelected?.Invoke(hairItem);
        }
    }
}
