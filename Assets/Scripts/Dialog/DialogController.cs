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

    public DialogSO dialogPanelSO;
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

    private void OnCollisionEnter2D(Collision2D other) {
    
    }

     public void Init() {
        _dialogText = transform.Find("DialogPanel/DialogText").GetComponent<TMP_Text>();
        
        _option1 = transform.Find("DialogPanel/Options/Option1").GetComponent<TMP_Text>();
        _option2 = transform.Find("DialogPanel/Options/Option2").GetComponent<TMP_Text>();
        _option3 = transform.Find("DialogPanel/Options/Option3").GetComponent<TMP_Text>();

        _options = new List<TMP_Text>();
        _options.Add(_option1);
        _options.Add(_option2);
        _options.Add(_option3);

        _background = transform.Find("Background").GetComponent<Image>();
        _background.sprite = dialogPanelSO.background;

        _characterSingle = transform.Find("DialogPanel/CharacterSingle").GetComponent<Image>();
        _characterSingle.sprite = dialogPanelSO.characterSingle;
        if(_characterSingle.sprite == null) {
            _characterSingle.gameObject.SetActive(false);
        }

        _dialogEnd = transform.Find("DialogPanel/DialogEnd").GetComponent<Button>();
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
            _dialogEnd.gameObject.SetActive(true);
        }

        for(int i = 0; i < choices.Count; i++) {
            _options[i].gameObject.SetActive(true);
            _options[i].text = choices[i].text;
        }
    }
    
    public void setStoryOption(int choice) {
        Choice selected = story.currentChoices[choice];
        //Check if choices have tags associated
        List<string> tags = selected.tags;
        if(tags != null) {
            Debug.Log("Una opcion ha generado " + tags.Count + " tags");
            TagParser.Instance.ParseTag(tags[0]);
        }

        story.ChooseChoiceIndex(choice);
        UpdateDialogText(story.ContinueMaximally());
        UpdateAllOptions(story.currentChoices);
   }

   

    private void initStory() {
        UpdateDialogText(story.ContinueMaximally());
        UpdateAllOptions(story.currentChoices);
    }

    public void DialogEnd() {
        onDialogEnd.Invoke();
    }

}
