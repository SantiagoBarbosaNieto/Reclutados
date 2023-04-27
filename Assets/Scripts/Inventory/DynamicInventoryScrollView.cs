using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicInventoryScrollView : MonoBehaviour {

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;

    private List<RegateoProduct> inventoryProducts;

    public void UpdateUI() {
        ClearChildren();
        Debug.Log("UPDATE INV");
        inventoryProducts = GameStateManager.Instance._backpack._items;

        foreach(RegateoProduct product in inventoryProducts) {
            GameObject newProduct = Instantiate(prefab, scrollViewContent);

            if(newProduct.TryGetComponent<InventoryScrollViewItem>(out InventoryScrollViewItem item)) {
                item.ChangeNameAndQuantity(product.name, product.quantity.ToString());
            }
        }
    }

    public void ClearChildren() {
        Debug.Log("DELETING CHILDREN");
        foreach (Transform child in scrollViewContent) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
