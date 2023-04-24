using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using TMPro;

public class OptionsMenuManager : MonoBehaviour {
    
    public GameObject optionsMenu;
    public GameObject saveButton;
    public GameObject backToTitleButton;
    public GameObject settingsIcon;
    public LoadSceneRequestGameEvent titleEvent;
    public GameEvent saveGameEvent;
    public SceneSO titleSO;
    private Scene currentScene;
    public GameObject notificationObject;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationContent;

    void Update() {
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "TitleScreen") {
            saveButton.gameObject.SetActive(false);
            backToTitleButton.gameObject.SetActive(false);
        }
        else {
            saveButton.gameObject.SetActive(true);
            backToTitleButton.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
    }

    public void SaveGame()
    {
        saveGameEvent.Raise();
    }

    public void OpenMenu() {
        Debug.Log("Open Menu");
        settingsIcon.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(true);
    }

    public void CloseMenu() {
        optionsMenu.gameObject.SetActive(false);
        settingsIcon.gameObject.SetActive(true);
    }

    public void BackToTitle() {
        notificationTitle.text = "Se perderá el progreso no guardado";
        notificationContent.text = "Guarde la partida antes de continuar";
        notificationObject.gameObject.SetActive(true);
    }

    public void BackToTitleTrue() {
        notificationObject.gameObject.SetActive(false);
        LoadSceneRequest request = new LoadSceneRequest(titleSO, false);
        titleEvent.Raise(request);
        optionsMenu.gameObject.SetActive(false);
        settingsIcon.gameObject.SetActive(true);
    }

    public void BackToTitleFalse() {
        notificationObject.gameObject.SetActive(false);
    }
}
