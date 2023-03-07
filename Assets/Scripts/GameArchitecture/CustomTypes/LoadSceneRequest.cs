[System.Serializable]
public class LoadSceneRequest
{
    public SceneSO scene;
    public bool loadingScreen;

    public LoadSceneRequest(SceneSO scene, bool loadingScreen)
    {
        this.scene = scene;
        this.loadingScreen = loadingScreen;
    }
}
