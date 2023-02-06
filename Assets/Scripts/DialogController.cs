using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogController : MonoBehaviour
{

    private TMP_Text _dialogText;
    
    private TMP_Text _option1;
    private TMP_Text _option2;
    private TMP_Text _option3;

    private List<TMP_Text> _options;

    private Story story;
    public TextAsset inkAsset;


    // Start is called before the first frame update
    void Start()
    {
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
        story = new Story(inkAsset.text);
        initStory();
    }

    void UpdateDialogText(string newText) {
        _dialogText.text = newText;
    }

    void UpdateAllOptions(List<Choice> choices) {

        foreach (var option in _options) {
            option.gameObject.SetActive(false);
        }

        if(choices.Count > 3) {
            Debug.LogError("The choices could not be loaded: A maximum of three choices is required");
        }
        else if(choices.Count <= 0) {
            Debug.LogError("The choices could not be loaded: At least one choice is required");
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

}
