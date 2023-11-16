using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HairItem", menuName = "Shop/HairItem")]
public class HairItem : ShopItem
{
    [field: SerializeField] public HairTypes HairType { get; private set; }
}
