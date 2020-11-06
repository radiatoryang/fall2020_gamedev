using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Custom/ShopItem")]
public class ShopItem : ScriptableObject
{
    [System.Serializable] // tells Unity that this can be "serialized" (saved) in Inspector
    public class ItemData {
        public string itemName;
        public int itemCost;
        public Sprite itemIcon;
    }

    public ItemData itemData; // IMPORTANT: we declared a class above, but we need to declare the variable too

}
