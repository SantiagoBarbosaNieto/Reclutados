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

    private TMP_Text _characterSingleName;

    private Transform _optionsContainer;

    private TMP_Text _dialogEnd;
    private Button _fastForward;

    public int _initialTypeSpeed = 10;

    [Range(0, 20)]
    public int typeWriterSpeed = 0;

    private string debugText = "";
    
    private Coroutine textTypeWritingCoroutine;

    private List<TMP_Text> _options;

    private Story story;

    private void OnCollisionEnter2D(Collision2D other) {
    
    }

     public void Init() {
        _dialogText = transform.Find("DialogPanel/DialogText").GetComponent<TMP_Text>();
        
        _option1 = transform.Find("DialogPanel/Options/Option1").GetComponent<TMP_Text>();
        _option2 = transform.Find("DialogPanel/Options/Option2").GetComponent<TMP_Text>();
        _option3 = transform.Find("DialogPanel/Options/Option3").GetComponent<TMP_Text>();
        
        _optionsContainer = transform.Find("DialogPanel/Options");

        _options = new List<TMP_Text>();
        _options.Add(_option1);
        _options.Add(_option2);
        _options.Add(_option3);

        _background = transform.Find("Background").GetComponent<Image>();
        _background.sprite = dialogPanelSO.background;

        _characterSingle = transform.Find("DialogPanel/CharacterSingle").GetComponent<Image>();
        _characterSingleName = transform.Find("DialogPanel/CharacterSingle/Nombre").GetComponent<TMP_Text>();
        _characterSingle.sprite = dialogPanelSO.characterSingle;
        if(_characterSingle.sprite == null) {
            _characterSingle.gameObject.SetActive(false);
        }

        _dialogEnd = transform.Find("DialogPanel/Options/DialogEnd").GetComponent<TMP_Text>();
        _dialogEnd.gameObject.SetActive(false);

        _fastForward = transform.Find("DialogPanel/FastForward").GetComponent<Button>();

        story = new Story(dialogPanelSO.inkText.text);
        initStory();
        UpdateName();
    }

    private void UpdateDialogText(string newText) {
        _optionsContainer.gameObject.SetActive(false);
        _dialogText.text = "";
        debugText = newText;
        typeWriterSpeed = _initialTypeSpeed;
        textTypeWritingCoroutine = StartCoroutine(PrintTextCoroutine());

    }

    private IEnumerator PrintTextCoroutine()
    {
        float delay = 1f / typeWriterSpeed;
        delay = 0.1f/(3+typeWriterSpeed);
        for (int i = 0; i < debugText.Length; i++)
        {
            _dialogText.text += debugText[i];
            yield return new WaitForSeconds(delay);
        } 
        _optionsContainer.gameObject.SetActive(true);
        _fastForward.gameObject.SetActive(false);
    }

    //private IEnumerator AppearText(TMP_Text t, string newText, string backgroundColor, string foregroundColor)
    //{   
    //    string stopColor = "</color>";
    //    string finalString = "";
    //    for(int i = 0; i < newText.Length; i++)
    //    {
    //        finalString = foregroundColor + newText.Substring(0, i) + stopColor + backgroundColor + newText.Substring(i, newText.Length-i) + stopColor;
    //        t.text = finalString;
    //        yield return new WaitForSeconds(0.1f/(3+typeWriterSpeed));
    //    }
    //    _optionsContainer.gameObject.SetActive(true);
    //    _fastForward.gameObject.SetActive(false);
//
    //    yield return null;
    //}
//
    private void UpdateAllOptions(List<Choice> choices) {

        foreach (var option in _options) {
            option.gameObject.SetActive(false);
        }

        if(choices.Count == 0) {
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
            foreach(var tag in tags) {
                TagParser.Instance.ParseTag(tag);
            }
        }
        typeWriterSpeed = _initialTypeSpeed;
        _fastForward.gameObject.SetActive(true);

        story.ChooseChoiceIndex(choice);
        UpdateDialogText(story.ContinueMaximally());
        UpdateAllOptions(story.currentChoices);
   }

   private void UpdateName(){
         if(_characterSingle.sprite != null) {
                _characterSingleName.gameObject.SetActive(true);
                _characterSingleName.text = _characterSingle.sprite.name;
          }
          else
          {
            _characterSingleName.gameObject.SetActive(false);
          }
          
   }

   

    private void initStory() {
        UpdateDialogText(story.ContinueMaximally());
        UpdateAllOptions(story.currentChoices);
    }

    public void DialogEnd() {
        onDialogEnd.Invoke();
    }
    public void FastForward() {
        StopCoroutine(textTypeWritingCoroutine);
        _dialogText.text = debugText;
        _optionsContainer.gameObject.SetActive(true);
        _fastForward.gameObject.SetActive(false);
    }

}
