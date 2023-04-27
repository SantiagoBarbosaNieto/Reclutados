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
        int numItems = GameStateManager.Instance._backpack._numItems + quantityPerInteraction;
        NotificationContent eventInfo = new NotificationContent("¡Cultivo Recolectado!", "Se ha agregado x" + quantityPerInteraction + " " + itemName + " al inventario");

        if(numItems > maxItems) {
            eventInfo = new NotificationContent("¡No puedes cargar más objetos!", "El número máximo que puedes cargar es " + maxItems);
            udpateAndShowNotificationEvent.Raise(eventInfo);
            return;
        }

        List<RegateoProduct> inventoryProducts = GameStateManager.Instance._backpack._items;

        foreach(RegateoProduct item in inventoryProducts) {
            Debug.Log(item.name);
            if(string.Compare(itemName, item.name) == 0) {
                Debug.Log("AGREGADO");
                item.quantity += 1;
                break;
            }
        }

        GameStateManager.Instance.SetBackpack(new GameStateManager.Backpack(maxItems, numItems, inventoryProducts));

        udpateAndShowNotificationEvent.Raise(eventInfo);
    }
}