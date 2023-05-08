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

    public void ChangeNameAndQuantity(int productId, string name, string quantity) {
        this.id = productId;
        this.itemName.text = name;
        this.itemQuantity.text = quantity;
        decreaseButton.gameObject.SetActive(false);
    }

    public void StartInfo(int productId, string name, string startQuantity, Action<int> decreaseCallback) {
        this.id = productId;
        this.itemName.text = name;
        this.itemQuantity.text = startQuantity;
        decreaseButton.gameObject.SetActive(true);
        decreaseButton.onClick.AddListener(() => decreaseCallback(this.id));
    }

    [SerializeField]
    public Button decreaseButton;

}
