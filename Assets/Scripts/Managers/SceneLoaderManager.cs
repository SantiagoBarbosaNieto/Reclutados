using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour {

    [Header("Dependencies")]
    public LoadingScreenUI loadingScreenUI;
    public GameObject dialogProgressionPrefab;
    public GameObject regateoProgressionPrefab;
    private LoadSceneRequest _pendingRequest;

    [SerializeField]
    private bool loadInitialScene;
    [SerializeField]
    private SceneSO initialScene;

    private void Start() {
        if(loadInitialScene) {
            if(initialScene != null) {
                LoadSceneRequest request = new LoadSceneRequest(initialScene, false);
                StartCoroutine(LoadInitialScene(request));
            }   
        }
    }

    private IEnumerator LoadInitialScene(LoadSceneRequest request) {
        var sceneLoading = SceneManager.LoadSceneAsync(request.scene.name, LoadSceneMode.Additive);

        while(!sceneLoading.isDone) {
            yield return null;
        }

        var loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);
    }


    // Function that will be called from a listener
    public void OnLoadMenuRequest(LoadSceneRequest request) {
        if (IsSceneAlreadyLoaded(request.scene) == false) {
            StartCoroutine(ProcessLevelLoading(request));
        }
    }

    // Function that will be called from a listener
    public void OnLoadLevelRequest(LoadSceneRequest request) {

        if (IsSceneAlreadyLoaded(request.scene)) {
            // Level is already loaded. Activate it
            ActivateLevel(request);
        }
        else {
            // Level is not loaded
            if (request.loadingScreen) {
                // If a loading screen is requested, then show it and wait
                this._pendingRequest = request;
                this.loadingScreenUI.ToggleScreen(true);
            }
            else {
                // If no loading screen requeste, load it ASAP
                StartCoroutine(ProcessLevelLoading(request));
            }
        }
    }

    public void OnLoadDialogProgressionRequest(LoadDialogSceneRequest request) {
        // Level is not loaded
        if (request.loadingScreen) {
            // If a loading screen is requested, then show it and wait
            this._pendingRequest = request;
            this.loadingScreenUI.ToggleScreen(true);
        }
        else {
            // If no loading screen requeste, load it ASAP
            StartCoroutine(ProcessDialogLoading(request));
        }

    }

    // Function that will be called from a listener
    public void OnLoadingScreenToggled(bool enabled) {

        if (enabled && this._pendingRequest != null) {
            // When loading screen is shown, we receive the event and can load the new level
            StartCoroutine(ProcessLevelLoading(this._pendingRequest));
        }
    }

    private bool IsSceneAlreadyLoaded(SceneSO scene) {

        Scene loadedScene = SceneManager.GetSceneByName(scene.name);

        if (loadedScene != null && loadedScene.isLoaded == true)
            return true;
        else
            return false;
    }

    private IEnumerator ProcessLevelLoading(LoadSceneRequest request) {

        if (request.scene != null) {
            var currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(request.scene.name, LoadSceneMode.Additive);

            // Level is being loaded, it could take some seconds (or not). Waiting until is fully loaded
            while (!loadSceneProcess.isDone) {
                yield return null;
            }

            // Once the level is ready, activate it!
            ActivateLevel(request);
        }
    }

    private IEnumerator ProcessDialogLoading(LoadDialogSceneRequest request) {

        if (request.scene != null) {
            var currentLoadedLevel = SceneManager.GetActiveScene();
            SceneManager.UnloadSceneAsync(currentLoadedLevel);

            AsyncOperation loadSceneProcess = SceneManager.LoadSceneAsync(request.scene.name, LoadSceneMode.Additive);

            // Level is being loaded, it could take some seconds (or not). Waiting until is fully loaded
            while (!loadSceneProcess.isDone) {
                yield return null;
            }

            // Once the level is ready, activate it!
            if(request.scene.name.Equals("Regateo"))
                ActivateRegateoDialogProgression(request);
            else
                ActivateDialogProgression(request);
        }
    }

    private void ActivateLevel(LoadSceneRequest request) {

        // Set active
        var loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);

        // Hide black loading screen
        if (request.loadingScreen) {
            this.loadingScreenUI.ToggleScreen(false);
        }

        // Clean status
        this._pendingRequest = null;
    }

    private void ActivateRegateoDialogProgression(LoadDialogSceneRequest request)
    { 
        // Set active
        var loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);
        var regateoProgressionControl = GameObject.Instantiate(regateoProgressionPrefab);
        regateoProgressionControl.SetActive(false);
        if(GameObject.Find("RegateoCanvas") == null)
            Debug.Log("NAME: ");
        //Set controller items
        var canvas = GameObject.Find("RegateoCanvas").GetComponent<Canvas>();
        MultiRegateoController controller = regateoProgressionControl.GetComponent<MultiRegateoController>();
        controller.canvas = canvas;
        controller.dialogProgressionSO = request.dialogs;

        regateoProgressionControl.SetActive(true);
        // Hide black loading screen
        if (request.loadingScreen) {
            this.loadingScreenUI.ToggleScreen(false);
        }

        // Clean status
        this._pendingRequest = null;
    }

    private void ActivateDialogProgression(LoadDialogSceneRequest request) {
        // Set active
        var loadedLevel = SceneManager.GetSceneByName(request.scene.name);
        SceneManager.SetActiveScene(loadedLevel);
        var dialogProgressionControl = GameObject.Instantiate(dialogProgressionPrefab);
        dialogProgressionControl.SetActive(false);
        //Set controller items
        var canvas = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        MultiDialogController controller = dialogProgressionControl.GetComponent<MultiDialogController>();
        controller.canvas = canvas;
        controller.dialogProgressionSO = request.dialogs;

        dialogProgressionControl.SetActive(true);
        // Hide black loading screen
        if (request.loadingScreen) {
            this.loadingScreenUI.ToggleScreen(false);
        }

        // Clean status
        this._pendingRequest = null;
    }
}
