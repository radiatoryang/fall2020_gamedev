using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PURPOSE: show how to load and save data with JSONUtility and PlayerPrefs
// USAGE: put this on a Text UI object
public class ShoppingCart : MonoBehaviour
{
    public static ShoppingCart Instance; // lazy singleton
    public List<ShopItem.ItemData> myCart = new List<ShopItem.ItemData>();
    public Text cartTextDisplay; // assign in Inspector!

    void Start()
    {
        Instance = this; // lazy singleton
    }

    void Update()
    {   // display shopping cart list contents as text list
        cartTextDisplay.text = "";
        foreach ( ShopItem.ItemData eachItem in myCart ) {
            cartTextDisplay.text += eachItem.itemName;
            cartTextDisplay.text += "... " + eachItem.itemCost.ToString();
            cartTextDisplay.text += "\n";
        }
    }

    // called by a Button!
    public void LoadData () {
        // don't recover PlayerPrefs data unless we know there's PlayerPrefs data already there
        if ( PlayerPrefs.HasKey("shoppingSaveData") ) {
            string data = PlayerPrefs.GetString("shoppingSaveData");

            // deserialize: reconstructing game state from a string
            JsonUtility.FromJsonOverwrite( data, this );
        }
    }

    // called by a Button!
    public void SaveData () {
        // serializing data: transforming it into a string
        string data = JsonUtility.ToJson(this, true);
        Debug.Log( data );

        // save data: write to disk using PlayerPrefs
        PlayerPrefs.SetString("shoppingSaveData", data);
        PlayerPrefs.Save(); // important! don't forget to Save!

    }

}
