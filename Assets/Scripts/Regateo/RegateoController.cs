using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.Events;

public class RegateoController : MonoBehaviour
{
    
    public UnityEvent onDialogEnd;

    public DialogSO dialogPanelSO;

    public GameObject optionPrefab; 

    private TMP_Text _dialogText;
    
    private Transform _optionsContainer;

    private Image _background;
    private Image _character1;
    private Image _character2;
    private Image _characterSingle;

    private Button _dialogEnd;

    private List<GameObject> _options;

    private Story story;

    private void OnCollisionEnter2D(Collision2D other) {
    
    }

     public void Init() {
        _dialogText = transform.Find("DialogPanel/DialogText").GetComponent<TMP_Text>();
        
        _optionsContainer = transform.Find("OptionsPanel/Scroll View/Viewport/Content");

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

        if(choices.Count == 0) {
            transform.Find("OptionsPanel").gameObject.SetActive(false);
            _dialogEnd.gameObject.SetActive(true);
        }
        else
        {
            transform.Find("OptionsPanel").gameObject.SetActive(true);
        }
        if(_options != null)
        {
            foreach(GameObject op in _options)
            {
                Destroy(op);
            }
        }
        _options = new List<GameObject>();
        for(int i = 0; i < choices.Count; i++) {
            Transform instance = Instantiate(optionPrefab,  _optionsContainer.transform).transform;
            instance.SetParent(_optionsContainer);
            instance.GetComponent<RegateoOptionClick>().optionIndex = i;
            instance.GetComponent<RegateoOptionClick>().controller = gameObject.GetComponent<RegateoController>();
            instance.GetComponent<RegateoOptionClick>().soundPlayer = gameObject.transform.Find("Audio/Click").GetComponent<AudioSource>();
            TMP_Text opTitle = instance.GetChild(0).GetComponent<TMP_Text>();
            opTitle.text = "Option " +  (i+1); 
            TMP_Text op = instance.GetChild(1).GetComponent<TMP_Text>();
            op.text = choices[i].text;
            
            _options.Add(instance.gameObject);
        }
    }
    
    public void setStoryOption(int choice) {
        Choice selected = story.currentChoices[choice];
        //Check if choices have tags associated
        List<string> tags = selected.tags;
        if(tags != null) {
            Debug.Log("Una opcion ha generado " + tags.Count + " tags");
            TagParser.ParseTag(tags[0]);
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
