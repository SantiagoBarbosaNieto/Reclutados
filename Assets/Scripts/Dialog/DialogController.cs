using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.Events;

public class DialogController : MonoBehaviour
{
    public UnityEvent onDialogEnd;

    public DialogPanelSO dialogPanelSO;
    private TMP_Text _dialogText;
    
    private TMP_Text _option1;
    private TMP_Text _option2;
    private TMP_Text _option3;

    private Image _background;
    private Image _character1;
    private Image _character2;
    private Image _characterSingle;

    private Button _dialogEnd;

    private List<TMP_Text> _options;

    private Story story;

     public void Init() {
        _dialogText = transform.Find("DialogText").GetComponent<TMP_Text>();
        
        _option1 = transform.Find("Option1").GetComponent<TMP_Text>();
        Debug.Log("Option 1 set to: " + _option1.text);
        _option2 = transform.Find("Option2").GetComponent<TMP_Text>();
        Debug.Log("Option 2 set to: " + _option2.text);
        _option3 = transform.Find("Option3").GetComponent<TMP_Text>();
        Debug.Log("Option 3 set to: " + _option3.text);

        _options = new List<TMP_Text>();
        _options.Add(_option1);
        _options.Add(_option2);
        _options.Add(_option3);

        _background = transform.Find("Background").GetComponent<Image>();
        _background.sprite = dialogPanelSO.background;

        _characterSingle = transform.Find("CharacterSingle").GetComponent<Image>();
        _characterSingle.sprite = dialogPanelSO.characterSingle;

        _dialogEnd = transform.Find("DialogEnd").GetComponent<Button>();
        _dialogEnd.gameObject.SetActive(false);

        story = new Story(dialogPanelSO.inkText.text);
        initStory();
    }

    private void UpdateDialogText(string newText) {
        _dialogText.text = newText;
    }

    private void UpdateAllOptions(List<Choice> choices) {

        foreach (var option in _options) {
            option.gameObject.SetActive(false);
        }

        if(choices.Count > 3) {
            Debug.LogError("The choices could not be loaded: A maximum of three choices is required");
        }
        else if(choices.Count == 0) {
            //Do something when the dialog ends
            Debug.Log("Dialog ended");
            _dialogEnd.gameObject.SetActive(true);
        }

        for(int i = 0; i < choices.Count; i++) {
            _options[i].gameObject.SetActive(true);
            _options[i].text = choices[i].text;
        }
    }
    
    public void setStoryOption(int choice) {
        story.ChooseChoiceIndex(choice);
        UpdateDialogText(story.ContinueMaximally());

        UpdateAllOptions(story.currentChoices);
    }

   

    private void initStory() {
        UpdateDialogText(story.ContinueMaximally());
        UpdateAllOptions(story.currentChoices);
    }

    public void DialogEnd() {
        Debug.Log("Calling dialog end event");
        onDialogEnd.Invoke();
    }

}
