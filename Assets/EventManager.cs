using UnityEngine;
using ScriptableObjectArchitecture;

public class EventManager : MonoBehaviour
{

    public static EventManager Instance {get; private set;}

    public GameEvent NoMoneyEvent;

    public GameEvent AdvanceDayEvent;
    public LoadDayRequestGameEvent LoadDayEvent;
    public LoadDialogSceneRequestGameEvent LoadDialogSceneEvent;
    public LoadSceneRequestGameEvent LoadSceneEvent;


    public FloatGameEvent AddMoneyEvent; 
    public IntGameEvent IncreaseCollaborationEvent;
    public IntGameEvent EndBranchEvent;


    
    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }


    public void AdvanceDay() {
        Debug.Log("Advance day event triggered");
        AdvanceDayEvent.Raise();
    }

    public void LoadDay(LoadDayRequest request) {
        Debug.Log("Load day event triggered");
        LoadDayEvent.Raise(request);
    }


    public void LoadDialogScene(LoadDialogSceneRequest request) {
        Debug.Log("Load dialog scene event triggered");
        LoadDialogSceneEvent.Raise(request);
    }

    public void LoadScene(LoadSceneRequest request) {
        Debug.Log("Load scene event triggered");
        LoadSceneEvent.Raise(request);
    }

    public void AddMoney(float amount) {
        Debug.Log("Add money event triggered");
        AddMoneyEvent.Raise(amount);
    }

    public void IncreaseCollaboration() {
        Debug.Log("Load dialog scene event triggered");
        IncreaseCollaborationEvent.Raise(1);
    }

    public void EndBranch(int branch) {
        EndBranchEvent.Raise(branch);
    }

}
