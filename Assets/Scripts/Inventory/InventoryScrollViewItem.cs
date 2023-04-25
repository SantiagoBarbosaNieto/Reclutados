using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryScrollViewItem : MonoBehaviour {

    [SerializeField]
    private TMP_Text itemName;

    [SerializeField]
    private TMP_Text itemQuantity;

    public void ChangeNameAndQuantity(string name, string quantity) {
        itemName.text = name;
        itemQuantity.text = quantity;
    }

}
