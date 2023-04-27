//Inventory Scroll View
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InventoryScrollViewItem : MonoBehaviour {

    [SerializeField]
    private TMP_Text itemName;

    [SerializeField]
    private TMP_Text itemQuantity;

    private int id;

    public void ChangeNameAndQuantity(string name, string quantity) {
        itemName.text = name;
        itemQuantity.text = quantity;
    }

    public void StartInfo(int productId, string name, string startQuantity, Action<int> decreaseCallback )
    {
        this.id = productId;
        this.itemName.text = name;
        this.itemQuantity.text = startQuantity;

        decreaseButton.onClick.AddListener(() => decreaseCallback(this.id));
    }

    [SerializeField]
    public Button decreaseButton;

}
