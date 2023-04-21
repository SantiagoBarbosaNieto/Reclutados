using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
using System;

public class ScreenMessage : MonoBehaviour {
    public GameObject popUpBox;
    public GameObject player;
    public TMP_Text popUpText;
    public TransitionItemGameEvent gameEvent;


    public void PopUp() {

        int dinero = UnityEngine.Random.Range(1, 5);
        int opcion = UnityEngine.Random.Range(0, 3);

        String[] posibleEventsDescription = new String[4];
        posibleEventsDescription[0] = "¿...? Escuchas sonidos extraños viniendo del bosque. Será mejor ignorarlos...";
        posibleEventsDescription[1] = "*Te limpias el sudor de la frente* ¡El calor es insoportable!";
        posibleEventsDescription[2] = "*Ves algo en el camino* ¡Encontraste $" + dinero + " en el suelo!";
        posibleEventsDescription[3] = "*Tropiezas con una roca* ¡Se te cayeron $" + dinero + " del bolsillo!";

        if(PrefsManager.Instance.getEventHappended() == 0) {

            Debug.Log("OPCIÓN ");
            Debug.Log(opcion);

            player.SetActive(false);
            popUpBox.SetActive(true);
            popUpText.text = posibleEventsDescription[opcion];
            PrefsManager.Instance.eventHappendedTrue();

            Debug.Log("EVENT CALLED");

            if(opcion == 2) {
                TransitionItem item = new TransitionItem(PrefsManager.Instance.GetDay(), 1, "Dinero que encontraste", dinero);
                gameEvent.Raise(item);
                PrefsManager.Instance.UpdateMoney(dinero);
            }
            else if(opcion == 3) {
                TransitionItem item = new TransitionItem(PrefsManager.Instance.GetDay(), 1, "Dinero que perdiste", -dinero);
                gameEvent.Raise(item);
                PrefsManager.Instance.UpdateMoney(-dinero);
            }
        }    
    }

    public void ClosePopUp() {
        player.SetActive(true);
        popUpBox.SetActive(false);
    }

}