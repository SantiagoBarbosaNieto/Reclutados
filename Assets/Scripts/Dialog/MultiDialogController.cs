using UnityEngine;
using ScriptableObjectArchitecture;
using System.Collections;

public class MultiDialogController : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField]
    public GameObject dialogPrefab;

    [SerializeField]
    public DialogProgressionSO dialogProgressionSO;

    DialogController dialogController;

    private int currentDialog = 0;

    private GameObject dialogInstance;

    public GameEvent multiDialogEnd;

    private void Start() {
        StartCoroutine(DelayPlaySound(dialogProgressionSO.musicClip));
        ProgressDialog();
    }

    public void ProgressDialog() {
        dialogInstance = Instantiate(dialogPrefab, canvas.transform);
        dialogController = dialogInstance.GetComponent<DialogController>();
        dialogController.dialogPanelSO = dialogProgressionSO.dialogProgression[currentDialog];
        dialogController.onDialogEnd.AddListener(ChangeDialog);
        dialogController.Init();
    }

    //Called from the "Dialog End" Button within the dialogPrefab. This button is
    //only visible when a current dialog ends
    private void ChangeDialog() {
        

        Debug.Log("Dialog end event received");
        currentDialog++;

        //If the current dialog is the final dialog, then it cannot be changed
        //and a dialog progression end event is raised.
        if(currentDialog >= dialogProgressionSO.dialogProgression.Count) {
            Debug.Log("Dialog progression ended");
            AudioManager.Instance.StopSound();
            if(multiDialogEnd != null)
                multiDialogEnd.Raise();
        }
        else {
            Destroy(dialogInstance);
            ProgressDialog();
        }
    }

    IEnumerator DelayPlaySound(AudioClip clip) {
        Debug.Log("Delaying sound");
        yield return new WaitForSeconds(0.1f);
        AudioManager.Instance.PlaySound(clip);
    }

}
