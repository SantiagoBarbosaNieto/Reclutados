using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RegateoOptionClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text option;
    public int optionIndex;
    public RegateoController controller;
    public AudioSource soundPlayer;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        //play sfx
        soundPlayer.Play();
        //Send event to set option
        controller.setStoryOption(optionIndex);
    }

    void Start() {
        option = transform.GetChild(1).GetComponent<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        option.color = new Color(0.8f, 0.3f, 0.3f, 0.63f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        option.color = new Color(1f, 1f, 1f, 1f);
    }
}
