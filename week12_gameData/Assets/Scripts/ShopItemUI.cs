using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PURPOSE: show how to parse a ScriptableObject and put the data in UI components
// USAGE: put this on a button to buy an item defined by a ScriptableObject
public class ShopItemUI : MonoBehaviour
{
    public ShopItem scriptableObjectAsset; // assign in Inspector!

    public Text buttonLabelText; // assign in Inspector
    public Image buttonLabelIcon; // assign in Inspector

    void Update()
    {
        buttonLabelText.text = scriptableObjectAsset.itemData.itemName;
        buttonLabelIcon.sprite = scriptableObjectAsset.itemData.itemIcon;
    }

    // called by Button UI via UnityEvent in Inspector
    public void AddItemToCart () {
        ShoppingCart.Instance.myCart.Add( scriptableObjectAsset.itemData );
    }
}
