using System;
using UnityEngine;
using System.Collections.Generic;
using ScriptableObjectArchitecture;

public class CropsCollection : MonoBehaviour {

    [SerializeField]
    private NotificationContentGameEvent udpateAndShowNotificationEvent;

    [Header("Extra config")]
    public string validTag;
    private bool inCrop = false;
    public string itemName;
    public int quantityPerInteraction;

    void Update () {
		if(Input.GetKeyUp(KeyCode.E) && inCrop) {
            Debug.Log("Got E key");
            AddItemToBackpack();
        }
	}

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag(validTag)) {
            inCrop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag(validTag)) {
            inCrop = false;
        }
    }

    private void AddItemToBackpack() {
        int maxItems = GameStateManager.Instance._backpack._maxItems;
        int numItems = GameStateManager.Instance._backpack.GetNumItems() + quantityPerInteraction;
        NotificationContent eventInfo = new NotificationContent("¡Cultivo Recolectado!", "Se ha agregado x" + quantityPerInteraction + " " + itemName + " al inventario");

        if(numItems > maxItems) {
            eventInfo = new NotificationContent("¡No puedes cargar más objetos!", "El número máximo de productos que puedes cargar es " + maxItems);
            udpateAndShowNotificationEvent.Raise(eventInfo);
            return;
        }

        List<RegateoInventoryProduct> inventoryProducts = GameStateManager.Instance._backpack._items;

        foreach(RegateoInventoryProduct item in inventoryProducts) {
            Debug.Log(item.regateoProduct.name);
            if(string.Compare(itemName, item.regateoProduct.name) == 0) {
                Debug.Log("AGREGADO");
                item.AddQuantity(quantityPerInteraction);
                break;
            }
        }

        //This line is not necessary as the backpack is a reference to the one in GameStateManager therefore any changes should be reflected
        //in the original.

        //GameStateManager.Instance.SetBackpack(new GameStateManager.Backpack(maxItems, numItems, inventoryProducts));

        udpateAndShowNotificationEvent.Raise(eventInfo);
    }
}