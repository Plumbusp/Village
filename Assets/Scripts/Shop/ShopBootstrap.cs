using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBootstrap : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private PlayerLooks _playerLooks;

    private PersistantData _persistantData;
    private LocalDataProvider _localDataProvider;
    private Wallet _wallet;
    private void Awake()
    {
        InitializeData();
        InitializeWallet();
        InitializeShop();
    }
    private void InitializeData()
    {
        _persistantData = new PersistantData();
        _localDataProvider = new LocalDataProvider(_persistantData);
        TryToLoadOrInit();
    }
    private void InitializeWallet()
    {
        _wallet = new Wallet(_persistantData);
    }
    private void InitializeShop()
    {
        OpenItemChecker openItemChecker = new OpenItemChecker(_persistantData);
        SelectedItemChecker selectedItemChecker = new SelectedItemChecker(_persistantData);
        ItemSelector itemSelector = new ItemSelector(_persistantData);
        ItemUnlocker itemUnlocker = new ItemUnlocker(_persistantData);
        ItemInitialSetter itemInitialSetter = new ItemInitialSetter(_persistantData,_shop.GetShopContent());
        _playerLooks.Initialize(itemSelector, itemInitialSetter);
        _shop.Initialize(itemSelector, itemUnlocker, selectedItemChecker, openItemChecker,itemInitialSetter, _wallet, _localDataProvider);
    }
    private void TryToLoadOrInit()
    {
        if (_localDataProvider.TryLoad() == false)
            _persistantData.PlayerData = new PlayerData();
    }
}
