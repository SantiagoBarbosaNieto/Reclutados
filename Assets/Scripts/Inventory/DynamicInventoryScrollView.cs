//DynamicInventoryScrollView
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;
using System;

public class DynamicInventoryScrollView : MonoBehaviour {

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;

    private List<RegateoInventoryProduct> inventoryProducts;

    public IntGameEvent increaseBackpackItemQuantityEvent;
    public IntGameEvent decreaseBackpackItemQuantityEvent;

    void Start() {
        UpdateUI();
    }

    public void UpdateUI() {
        ClearChildren();
        inventoryProducts = GameStateManager.Instance._backpack._items;

        foreach(RegateoInventoryProduct product in inventoryProducts) {
            GameObject newProduct = Instantiate(prefab, scrollViewContent);

            if(newProduct.TryGetComponent<InventoryScrollViewItem>(out InventoryScrollViewItem item)) {

                if(SceneManager.GetActiveScene().name == "Farm" || SceneManager.GetActiveScene().name == "Road") {
                    Debug.Log("************************************************************ A");
                    item.StartInfo(product.regateoProduct.id,product.regateoProduct.name, product.quantity.ToString(), DecreaseQuantity);
                }
                else {
                    Debug.Log("************************************************************ B");
                    item.ChangeNameAndQuantity(product.regateoProduct.id,product.regateoProduct.name, product.quantity.ToString());
                }
            }
        }
    }

    public void IncreaseQuantity(int id) {
        increaseBackpackItemQuantityEvent.Raise( id);
    }

    public void DecreaseQuantity(int id) {
        decreaseBackpackItemQuantityEvent.Raise(id);
    }

    public void ClearChildren() {
        foreach (Transform child in scrollViewContent) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
