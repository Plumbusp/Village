using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<int> OnMoneyChange;
    private PersistantData _persistantData;
    public Wallet(PersistantData persistantData) => _persistantData = persistantData;

    public bool IsEnough(int coins) => _persistantData.PlayerData.Money >= coins;
    public void Spend(int coins)
    {
        if(coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _persistantData.PlayerData.Money -= coins;
        OnMoneyChange?.Invoke(coins);
    }
    public void AddCoins(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException(nameof(coins));

        _persistantData.PlayerData.Money += coins;
        OnMoneyChange?.Invoke(coins);
    }

}
