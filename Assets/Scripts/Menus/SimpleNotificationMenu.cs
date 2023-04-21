// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using ScriptableObjectArchitecture;

public class SimpleNotificationMenu : MonoBehaviour {

    public GameObject notificationObject;
    public void CloseNotification() {
        notificationObject.gameObject.SetActive(false);
    }
}
