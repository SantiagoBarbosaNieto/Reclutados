// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour {

    public GameObject inventoryUI;
    public GameObject inventoryButton;
    private Scene currentScene;

    void Update() {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "TitleScreen") {
            inventoryButton.gameObject.SetActive(false);
        }
        else {
            inventoryButton.gameObject.SetActive(true);
        }
    }

    public void OpenInventory() {
        inventoryUI.gameObject.SetActive(true);
    }
    public void CloseInventory() {
        inventoryUI.gameObject.SetActive(false);
    }
}
