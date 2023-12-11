public class ItemSelector : IShopItemVisiter
{
    private PersistantData _persistantData;
    public ItemSelector(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }
    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatItem hatItem)
    {
        _persistantData.PlayerData.SelectedHat = hatItem.HatType;
    }

    public void Visit(HairItem hairItem)
    {
       _persistantData.PlayerData.SelectedHair = hairItem.HairType;
    }
}
