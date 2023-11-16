using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<HairItem> _hairItems;
    [SerializeField] private List<HatItem> _hatItems;

    private IEnumerable<HairItem> HairItems => _hairItems;
    private IEnumerable<HatItem> HatItems => _hatItems;
    private void OnValidate()
    {
        var hairItemsDublicates = _hairItems.GroupBy(item => item.HairType)
            .Where(array => array.Count() > 1);
        if(hairItemsDublicates.Count() > 0)
        {
            throw new InvalidOperationException(nameof(hairItemsDublicates));
        }
        var hatItemsDublicates = _hatItems.GroupBy(item => item.HatType)
        .Where(array => array.Count() > 1);
        if (hatItemsDublicates.Count() > 0)
        {
            throw new InvalidOperationException(nameof(hatItemsDublicates));
        }

    }
}
