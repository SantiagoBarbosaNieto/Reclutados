using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class ScreenMessage : MonoBehaviour {
    public GameObject popUpBox;
    public GameObject player;
    public TMP_Text popUpText;
    public TransitionItemGameEvent gameEvent;


    public void PopUp() {

        int dinero = Random.Range(1, 5);
        TransitionItem item = new TransitionItem(PrefsManager.Instance.GetDay(), 1, "Dinero que encontraste en el suelo", dinero);

        gameEvent.Raise(item);

        PrefsManager.Instance.AddMoney(dinero);

        if(PrefsManager.Instance.getEventHappended() == 0) {
            player.SetActive(false);
            popUpBox.SetActive(true);
            popUpText.text = "¡Encontraste $" + dinero + " en el suelo!";
        }       
    }

    public void ClosePopUp() {
        player.SetActive(true);
        popUpBox.SetActive(false);
        PrefsManager.Instance.eventHappendedTrue();
    }

}