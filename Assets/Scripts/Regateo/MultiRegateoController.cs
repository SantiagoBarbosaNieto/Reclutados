using UnityEngine;
using ScriptableObjectArchitecture;

public class MultiRegateoController : MonoBehaviour
{
    public Canvas canvas;

    [SerializeField]
    public GameObject dialogPrefab;

    [SerializeField]
    public DialogProgressionSO dialogProgressionSO;

    RegateoController regateoController;

    private int currentDialog = 0;

    private GameObject regateoInstance;

    public GameEvent multiDialogEnd;

    private void Start() {
        ProgressDialog();
    }

    public void ProgressDialog() {
        regateoInstance = Instantiate(dialogPrefab, canvas.transform);
        regateoController = regateoInstance.GetComponent<RegateoController>();
        regateoController.dialogPanelSO = dialogProgressionSO.dialogProgression[currentDialog];
        regateoController.onDialogEnd.AddListener(ChangeDialog);
        regateoController.Init();
        AudioManager.Instance.PlaySound(dialogProgressionSO.musicClip);
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
            if(PrefsManager.Instance == null)
                Debug.Log("ISNULL :/");
            PrefsManager.Instance.AddEvent("Ventas del día", PrefsManager.Instance.GetRegateoMoney());
            PrefsManager.Instance.SetRegateoMoney(0);
            multiDialogEnd.Raise();
        }
        else {
            Destroy(regateoInstance);
            ProgressDialog();
        }
    }

}
