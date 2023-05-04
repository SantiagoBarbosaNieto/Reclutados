// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;

public class InventoryMenu : MonoBehaviour {

    [SerializeField]
    public GameEvent UpdateInventory;

    public GameObject inventoryUI;
    public GameObject inventoryButton;
    private Scene currentScene;

    void Start() {
        UpdateInventoryUI();
    }

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
        UpdateInventory.Raise();
    }
    public void CloseInventory() {
        inventoryUI.gameObject.SetActive(false);
    }

    public void UpdateInventoryUI() {
        Debug.Log("Updating inventory UI");
        inventoryButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GameStateManager.Instance._backpack.GetNumItems() + "/" + GameStateManager.Instance._backpack._maxItems;
    }
}
