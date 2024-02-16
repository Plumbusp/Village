using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopCategoryButton _hatsButton;
    [SerializeField] private ShopCategoryButton _hairButton;
    [SerializeField] private ShopContent _shopContent;
    [SerializeField] private ShopPanel _shopPanel;

    private LocalDataProvider _dataProvider;

    private ShopItemView _previewedItem;  // The item that player is currently looking at. It updating in the SelectItem() (or in the OnSelectionButtonClick())

    private Wallet _wallet;

    [SerializeField] private PreviewImage _previewImage;
    [SerializeField]  private SelectButton _selectionButton;
    [SerializeField] private Image _selectedText;
    [SerializeField] private BuyButton _buyButton;

    private ItemSelector _itemSelector;
    private ItemUnlocker _itemUnlocker;
    private SelectedItemChecker _selectedItemChecker;
    private OpenItemChecker _openItemChecker;

    private ItemInitialSetter _initialSetter;

    ///// IN HERE WE ARE WORKING WITH 1 VIEW ITEM THAT IS CURRENTLY PREVIEWED //////
    private void OnEnable()
    {
        _hatsButton.Click += OnHatsCategoryButtonClick;
        _hairButton.Click += OnHairCategoryButtonClick;
        _shopPanel.OnItemViewClicked += OnItemViewClick;
        _buyButton.Click += OnBuyButtonClick;
        _selectionButton.Click += OnSelectionButtonClick;
    }
    private void OnDisable()
    {
        _hatsButton.Click -= OnHatsCategoryButtonClick;
        _hairButton.Click -= OnHairCategoryButtonClick;
        _shopPanel.OnItemViewClicked -= OnItemViewClick;
        _buyButton.Click -= OnBuyButtonClick;
        _selectionButton.Click -= OnSelectionButtonClick;
    }
    public void Initialize(ItemSelector _itemSelector, ItemUnlocker _itemUnlocker, SelectedItemChecker _selectedItemChecker, OpenItemChecker _openItemChecker, ItemInitialSetter itemInitialSetter, Wallet wallet, LocalDataProvider localDataprovider)
    {
        _wallet = wallet;
        this._itemSelector = _itemSelector;
        this._itemUnlocker = _itemUnlocker;
        this._selectedItemChecker = _selectedItemChecker;
        this._openItemChecker = _openItemChecker;
        this._initialSetter = itemInitialSetter;
        this._dataProvider = localDataprovider;
        _shopPanel.Initialize(_openItemChecker, _selectedItemChecker);

        _initialSetter.SetInitially();

        OnHairCategoryButtonClick();
    }

    private void OnHatsCategoryButtonClick()
    {
        _hatsButton.Selected();
        _hairButton.UnSelected();
        _shopPanel.Show(_shopContent.HatItems.Cast<ShopItem>());
    }
    private void OnHairCategoryButtonClick()
    {
        _hairButton.Selected();
        _hatsButton.UnSelected();
        _shopPanel.Show(_shopContent.HairItems.Cast<ShopItem>());
    }
    private void OnItemViewClick(ShopItemView shopItemView)
    {
        _previewedItem = shopItemView;
        _previewImage.ShowPreview(_previewedItem);
        _openItemChecker.Visit(_previewedItem.Item);
        if (_openItemChecker.isOpened)
        {
            _selectedItemChecker.Visit(_previewedItem.Item);
            if (_selectedItemChecker.isSelected)
            {
                ShowSelectedText();
                return;
            }
            ShowSelectionButton();
        }
        else
        {
            ShowBuyButton(shopItemView.Price);
        }
    }

    public void OnSelectionButtonClick()
    {
        ShowSelectedText();
        SelectItem();
    }
    public void HideSelectionButton() => _selectionButton.gameObject.SetActive(false);
    public void HideSelectedText() => _selectedText.gameObject.SetActive(false);
    public void HideBuyButton() => _buyButton.gameObject.SetActive(false);

    public ShopContent GetShopContent() => _shopContent;

    private void OnBuyButtonClick()  // called only if we have enought money, we check this in ShowbuyButton()
    {
        if (_wallet.IsEnough(_previewedItem.Price)) // Just double security level
        {
            _itemUnlocker.Visit(_previewedItem.Item);
            _wallet.Spend(_previewedItem.Price);
            _previewedItem.Unlock();
            SelectItem();
            ShowSelectedText();
            _dataProvider.Save();    // Сохраняем покупку
        }
    }
    private void ShowSelectionButton()
    {
        _selectionButton.gameObject.SetActive(true);
        HideSelectedText();
        HideBuyButton();
    }
    private void ShowSelectedText()
    {
        _selectedText.gameObject.SetActive(true);
        HideSelectionButton();
        HideBuyButton();
    }
    private void ShowBuyButton(int price)
    {
        _buyButton.gameObject.SetActive(true);
        _buyButton.UpdateText(price.ToString());
        if(_wallet.IsEnough(price))
        {
            _buyButton.Unlock();
        }
        else
        {
            _buyButton.Lock();
        }
        HideSelectionButton();
        HideSelectedText();
    }

    private void SelectItem()
    {
        _shopPanel.Select(_previewedItem);
        _itemSelector.Visit(_previewedItem.Item);
        _dataProvider.Save();
        ShowSelectedText();
    }
}
