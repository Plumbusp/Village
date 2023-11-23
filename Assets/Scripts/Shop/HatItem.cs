using UnityEngine;

[CreateAssetMenu(fileName = "HatItem", menuName = "Shop/HatItem")]
public class HatItem : ShopItem
{
   [field: SerializeField] public HatTypes HatType { get; private set; }
}
