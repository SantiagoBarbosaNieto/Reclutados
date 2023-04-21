// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private DaySO initialDay;
    [SerializeField]
    private LoadDayRequestGameEvent loadInitialDay;
    [SerializeField]
    private GameEvent startNewDay;

    public void NewGame() {
        LoadDayRequest request = new LoadDayRequest(initialDay);
        PrefsManager.Instance.ResetPrefs();
        loadInitialDay.Raise(request);
    }
    public void Exit() {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
