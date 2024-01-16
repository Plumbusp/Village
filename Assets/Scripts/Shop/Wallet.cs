using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet
{
    public Action<int> OnMoneyChange;
    private PersistantData _persistantData;
    public Wallet(PersistantData persistantData)
    {
        _persistantData = persistantData;
    }

    public bool IsEnough(int coins) => _persistantData.PlayerData.Money >= coins;
    public void Spend(int coins)
    {
        if(coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _persistantData.PlayerData.Money -= coins;
        OnMoneyChange?.Invoke(_persistantData.PlayerData.Money);
    }
    public void AddCoins(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _persistantData.PlayerData.Money += coins;
        OnMoneyChange?.Invoke(coins);
    }
    /// <summary>
    /// Called in the first load for updating the money text
    /// </summary>
    public void CallMoneyChange()
    {
        OnMoneyChange?.Invoke(_persistantData.PlayerData.Money);
    }
}
