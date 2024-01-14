using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLooks : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _hairImage;
    [SerializeField] private SpriteRenderer _hatImage;

    public void Initialize(ItemSelector itemSelector, ItemInitialSetter itemInitialSetter)
    {
        itemSelector.OnHairItemSelected += OnHairSelection;
        itemSelector.OnHatItemSelected += OnHatSelection;
        itemInitialSetter.OnInitialHairFound += OnHairSelection;
        itemInitialSetter.OnInitialHatFound += OnHatSelection;
    }

    private void OnHairSelection(HairItem item)
    {
        Debug.Log("Hair Selected");
        _hairImage.sprite = item.Image;
    }
    private void OnHatSelection(HatItem item)
    {
        Debug.Log("Hat Selected");
        _hatImage.sprite = item.Image;
    }
}
