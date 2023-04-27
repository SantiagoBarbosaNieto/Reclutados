using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicInventoryScrollView : MonoBehaviour {

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;

    private List<RegateoInventoryProduct> inventoryProducts;

    public void UpdateUI() {
        ClearChildren();
        Debug.Log("UPDATE INV UI");
        inventoryProducts = GameStateManager.Instance._backpack._items;

        foreach(RegateoInventoryProduct product in inventoryProducts) {
            GameObject newProduct = Instantiate(prefab, scrollViewContent);

            if(newProduct.TryGetComponent<InventoryScrollViewItem>(out InventoryScrollViewItem item)) {
                item.ChangeNameAndQuantity(product.regateoProduct.name, product.quantity.ToString());
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
