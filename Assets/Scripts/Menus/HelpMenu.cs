using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class HelpMenu : MonoBehaviour {

    public GameObject configurationObject;

    public void OpenMenu() {
        configurationObject.gameObject.SetActive(true);
    }
    public void CloseMenu() {
        configurationObject.gameObject.SetActive(false);
    }

}
