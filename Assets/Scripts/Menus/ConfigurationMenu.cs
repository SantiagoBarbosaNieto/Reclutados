// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;

public class ConfigurationMenu : MonoBehaviour {

    public GameObject configurationObject;

    public void OpenConfiguration() {
        configurationObject.gameObject.SetActive(true);
    }
    public void CloseConfiguration() {
        configurationObject.gameObject.SetActive(false);
    }
}
