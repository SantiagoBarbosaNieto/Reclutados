using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicInventoryScrollView : MonoBehaviour {

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private GameObject prefab;   

    private void Start() {

        List<RegateoProduct> allProducts = new List<RegateoProduct>() {
            new RegateoProduct("papa", "papas", 10, 0, 1),
            new RegateoProduct("plátano", "plátanos", 20, 0, 2)
        };

        foreach(RegateoProduct product in allProducts) {
            GameObject newProduct = Instantiate(prefab, scrollViewContent);

            if(newProduct.TryGetComponent<InventoryScrollViewItem>(out InventoryScrollViewItem item)) {
                item.ChangeNameAndQuantity(product.name, product.quantity.ToString());
            }
            
        }
    }

}
