using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Scriptable Objects/Scene")]
public class SceneSO : ScriptableObject {
    [Header("Scene Information")]
    public string sceneName;
    public string type;
}

public enum SceneType {
    DIALOG,
    LEVEL,
    TRANSITION,
    INFO
}