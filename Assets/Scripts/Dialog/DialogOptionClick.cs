using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DialogOptionClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text option;
    public int optionIndex;
    public DialogController controller;
    public AudioSource soundPlayer;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        //play sfx
        soundPlayer.Play();
        //Send event to set option
        controller.setStoryOption(optionIndex);
    }

    void Start() {
        option = GetComponent<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        option.color = new Color(0.8f, 0.3f, 0.3f, 0.63f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        option.color = new Color(1f, 1f, 1f, 1f);
    }
}
