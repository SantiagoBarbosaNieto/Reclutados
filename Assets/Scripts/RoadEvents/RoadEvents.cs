using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;
using System;

public class RoadEvents : MonoBehaviour {

    public GameEvent gameEvent;
    public GameObject popUpBox;
    public GameObject player;
    public TMP_Text popUpText;
    //TODO remove this
    //public TransitionItemGameEvent gameEvent;
    public AddMoneyGameEvent addMoneyEvent;

    public void RandomEvent() {

        int dinero = UnityEngine.Random.Range(1, 5);
        int opcion = UnityEngine.Random.Range(0, 4);

        String[] posibleEventsDescription = new String[4];
        posibleEventsDescription[0] = "¿...? Escuchas sonidos extraños viniendo del bosque. Será mejor ignorarlos...";
        posibleEventsDescription[1] = "*Te limpias el sudor de la frente* ¡El calor es insoportable!";
        posibleEventsDescription[2] = "*Ves algo en el camino* ¡Encontraste $" + dinero + " en el suelo!";
        posibleEventsDescription[3] = "*Tropiezas con una roca* ¡Se te cayeron $" + dinero + " del bolsillo!";

        if(!GameStateManager.Instance._roadEventHappened) {

            Debug.Log("OPCIÓN ");
            Debug.Log(opcion);

            player.SetActive(false);
            popUpBox.SetActive(true);
            popUpText.text = posibleEventsDescription[opcion];
            GameStateManager.Instance.SetRoadEventHappened(true);
            //TODO remove this
            //PrefsManager.Instance.eventHappendedTrue();

            Debug.Log("EVENT CALLED");

            if(opcion == 2) {
                AddMoney evento = new AddMoney(dinero, "Dinero que encontraste" );
                addMoneyEvent.Raise(evento);
                //TODO remove this
                //TransitionItem item = new TransitionItem(PrefsManager.Instance.GetDay(), 1, "Dinero que encontraste", dinero);
                //gameEvent.Raise(item);
                //PrefsManager.Instance.AddSalesMoney(dinero);
            }
            else if(opcion == 3) {
                AddMoney evento = new AddMoney(-dinero, "Dinero que perdiste" );
                addMoneyEvent.Raise(evento);
                
                //TODO remove this
                //TransitionItem item = new TransitionItem(PrefsManager.Instance.GetDay(), 1, "Dinero que perdiste", -dinero);
                //gameEvent.Raise(item);
                //PrefsManager.Instance.AddSalesMoney(-dinero);
            }
        }    
    }

    public void CloseRandomEventPopUp() {
        player.SetActive(true);
        popUpBox.SetActive(false);
    }

    public void AdvanceScene() {
        gameEvent.Raise();
    }

}