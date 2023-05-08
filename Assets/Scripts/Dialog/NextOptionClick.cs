using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NextOptionClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text option;
    public DialogController controller;
    public AudioSource soundPlayer;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(AudioManager.Instance != null)
        //play sfx
            AudioManager.Instance.PlaySound(soundPlayer.clip);
        else
            Debug.Log("There is no Audio manager on the scene to play the clip");
        //Send event to set option
        controller.DialogEnd();
    }

    void Start() {
        option = GetComponent<TMP_Text>();
        option.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        option.color = new Color(68f/255, 207f/255, 242f/255, 0.8f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        option.color = new Color(1f, 1f, 1f, 1f);
    }
}
