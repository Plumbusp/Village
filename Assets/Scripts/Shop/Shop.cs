using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopCategoryButton _hatsButton;
    [SerializeField] private ShopCategoryButton _hairButton;
    [SerializeField] private ShopContent _shopContent;
    [SerializeField] private ShopPanel _shopPanel;
    private void OnEnable()
    {
        _hatsButton.Click += OnHatsCategoryBattonClick;
        _hairButton.Click += OnHairCategoryButtonClick;
    }
    private void OnDisable()
    {
        _hatsButton.Click -= OnHatsCategoryBattonClick;
        _hairButton.Click -= OnHairCategoryButtonClick;
    }
    private void OnHatsCategoryBattonClick()
    {
        _hatsButton.Selected();
        _hairButton.UnSelected();
        _shopPanel.Show(_shopContent.HatItems);
    }
    private void OnHairCategoryButtonClick()
    {
        _hairButton.Selected();
        _hatsButton.UnSelected();
        _shopPanel.Show(_shopContent.HairItems);
    }
}
