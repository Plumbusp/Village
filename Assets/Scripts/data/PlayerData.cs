using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerData
{
    private HairTypes _selectedHair;
    private HatTypes _selectedHat;
    private List<HairTypes> _openHairs;
    private List<HatTypes> _openHats;
    private int _money;

    public PlayerData()
    {
        Debug.Log("DEFAULT");
        _money = 4000;
        _selectedHair = HairTypes.ShortBlackHair;
        _selectedHat = HatTypes.AstrastronautHelmet;
        _openHairs = new List<HairTypes> { _selectedHair};
        _openHats = new List<HatTypes> { _selectedHat };
    }
    [JsonConstructor]
    public PlayerData(int money, HairTypes seletedHair, HatTypes selectedHat, List<HairTypes>openHairs, List<HatTypes> openHats)
    {
        _money = money;
        _selectedHair = seletedHair;
        _selectedHat = selectedHat;
        _openHairs = openHairs;
        _openHats = openHats;
    }

    public HairTypes SelectedHair
    {
        get {
            return _selectedHair;
        }
        set
        {
            if (_openHairs.Contains(value))
                _selectedHair = value;
            else
                throw new ArgumentException(nameof(value));
        }
    }
    public HatTypes SelectedHat
    {
        get
        {
            return _selectedHat;
        }
        set
        {
            if (_openHats.Contains(value))
                _selectedHat = value;
            else
                throw new ArgumentException(nameof(value));
        }
    }
    public IEnumerable<HairTypes> OpenHairs => _openHairs;
    public IEnumerable<HatTypes> OpenHats => _openHats;
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

    public void OpenTheHair(HairTypes hair)
    {
        if(_openHairs.Contains(hair))
            throw new ArgumentException(nameof(hair));
        _openHairs.Add(hair);
    }
    public void OpenTheHat(HatTypes hat)
    {
        if(_openHats.Contains(hat))
            throw new ArgumentException(nameof(hat));
        _openHats.Add(hat);
    }
}
