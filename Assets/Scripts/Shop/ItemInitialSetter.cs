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
        Debug.Log("Started Setter");
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
        Debug.Log(OnInitialHairFound.GetInvocationList());
    }

    public void Visit(HatItem hatItem)   // We use HatItem Type here only for defining the right type of handling 
    {
        Debug.Log(_persistantData.PlayerData.SelectedHat);
        int i = 0;
        foreach (HatItem item in _shopContent.HatItems)
        {
            if (_persistantData.PlayerData.OpenHats.Contains(item.HatType))
            {
                if(_persistantData.PlayerData.SelectedHat == hatItem.HatType)
                {
                    i ++;
                    Debug.Log("Invoke Hat" + item.HatType + i);
                    OnInitialHatFound?.Invoke(item);
                }
            }
        }
    }

    public void Visit(HairItem hairItem)
    {
        Debug.Log(_persistantData.PlayerData.SelectedHair);
        foreach (HairItem item in _shopContent.HairItems)
        {
            if (_persistantData.PlayerData.OpenHairs.Contains(item.HairType))
            {
                if (_persistantData.PlayerData.SelectedHair == hairItem.HairType)
                {
                    Debug.Log("Invoke Hair" + item.HairType);
                    OnInitialHairFound?.Invoke(item);
                }
            }
        }
    }
}
    
