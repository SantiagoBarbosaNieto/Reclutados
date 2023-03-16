[System.Serializable]
public class LoadDialogSceneRequest: LoadSceneRequest
{
    public DialogProgressionSO dialogs;

    public LoadDialogSceneRequest(SceneSO scene, bool loadingScreen, DialogProgressionSO dialogs)
    : base(scene, loadingScreen)
    {
        this.dialogs = dialogs;
    }
}
