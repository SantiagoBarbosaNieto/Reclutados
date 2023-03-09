using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiDialogController : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField]
    public GameObject dialogPrefab;

    [SerializeField]
    public DialogProgressionSO dialogProgressionSO;

    UnityEvent onMultiDialogEnd;

    DialogController dialogController;

    private int currentDialog = 0;

    private GameObject dialogInstance;



    private void Start() {
        ProgressDialog();
    }

    public void ProgressDialog() {
        dialogInstance = Instantiate(dialogPrefab, canvas.transform);
        dialogController = dialogInstance.GetComponent<DialogController>();
        dialogController.dialogPanelSO = dialogProgressionSO.dialogProgression[currentDialog];
        dialogController.onDialogEnd.AddListener(ChangeDialog);
        dialogController.Init();
        AudioManager.Instance.PlaySound(dialogProgressionSO.musicClip);
    }

    private void ChangeDialog() {
        Debug.Log("Dialog end event received");
        currentDialog++;
        if(currentDialog >= dialogProgressionSO.dialogProgression.Count) {
            Debug.Log("Dialog progression ended");
            AudioManager.Instance.StopSound();
        }
        else {
            Destroy(dialogInstance);
            ProgressDialog();
        }
    }

}
