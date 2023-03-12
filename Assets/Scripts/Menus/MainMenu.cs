// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LoadDialogSceneRequestGameEvent newGameEvent;

    [SerializeField]
    private SceneSO initialScene;
    [SerializeField]
    private DialogProgressionSO initialDialogs;

    public void NewGame(){
        LoadDialogSceneRequest request = new LoadDialogSceneRequest(initialScene, false, initialDialogs);
        newGameEvent.Raise(request);
    }
    public void Exit()
    {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
