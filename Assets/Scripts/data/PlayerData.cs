using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData
{
    private HairItem _selectedHair;
    private HatItem _selectedHat;
    private List<HairItem> _openHairsItems;
    private List<HatItem> _openHatsItems;
    private int _money;

    public HairItem SelectedHair
    {
        get {
            return _selectedHair;
        }
        set
        {
            if (_openHairsItems.Contains(value))
                _selectedHair = value;
            else
                throw new ArgumentException(nameof(value)); 
        }
    }
    public HatItem SelectedHat
    {
        get
        {
            return _selectedHat;
        }
        set
        {
            if (_openHatsItems.Contains(value))
                _selectedHat = value;
            else
                throw new ArgumentException(nameof(value));
        }
    }
    public IEnumerable<HairItem> OpenHairsItems => _openHairsItems;
    public IEnumerable<HatItem> OpenHatsItems => _openHatsItems;
    public int Money
    {
        get {
            return _money;
        }
        set {
            if (value < 0)
                throw new ArgumentException(nameof(value));
            _money = value;
        }
    }
}
