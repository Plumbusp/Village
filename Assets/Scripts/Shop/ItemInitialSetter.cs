using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemInitialSetter
{
    public event Action<HatItem> OnInitialHatFound;
    public event Action<HairItem> OnInitialHairFound;

    private ShopContent _shopContent;
    private PersistantData _persistantData;
    public ItemInitialSetter(PersistantData persistantData,ShopContent shopContent) {
        _shopContent = shopContent;
        _persistantData = persistantData;
    }
    public void SetInitially() 
    {
        IEnumerable<HatItem> hatItems = _shopContent.HatItems;
        foreach (HatItem item in hatItems)
        {
            Visit(item);
        }
        IEnumerable<HairItem> hairItems = _shopContent.HairItems;
        foreach (HairItem item in hairItems)
        {
            Visit(item);
        }
    }

    public void Visit(HatItem hatItem)   // We use HatItem Type here only for defining the right type of handling 
    {
        if (_persistantData.PlayerData.OpenHats.Contains(hatItem.HatType))
        {
           if(_persistantData.PlayerData.SelectedHat == hatItem.HatType)
           {
               OnInitialHatFound?.Invoke(hatItem);
           }
        }
    }

    public void Visit(HairItem hairItem)
    {
        if (_persistantData.PlayerData.OpenHairs.Contains(hairItem.HairType))
        {
            if (_persistantData.PlayerData.SelectedHair == hairItem.HairType)
            {
                    OnInitialHairFound?.Invoke(hairItem);
            }
        }
    }
}
    
