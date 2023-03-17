// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private DaySO initialDay;
    [SerializeField]
    private LoadDayRequestGameEvent loadInitialDay;

    public void NewGame(){
        LoadDayRequest request = new LoadDayRequest(initialDay);
        loadInitialDay.Raise(request);
    }
    public void Exit()
    {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
