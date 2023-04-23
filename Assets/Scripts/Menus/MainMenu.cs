// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private GameEvent newGameEvent;

    [SerializeField]
    private GameEvent loadGameSaveEvent;

    public void NewGame() {
        newGameEvent.Raise();
    }

    public void LoadGame() {
        loadGameSaveEvent.Raise();
    }
    public void Exit() {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
