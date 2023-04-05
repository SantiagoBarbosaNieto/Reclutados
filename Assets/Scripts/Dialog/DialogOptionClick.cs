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
        if(AudioManager.Instance != null)
        //play sfx
            AudioManager.Instance.PlaySound(soundPlayer.clip);
        else
            Debug.Log("There is no Audio manager on the scene to play the clip");
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
