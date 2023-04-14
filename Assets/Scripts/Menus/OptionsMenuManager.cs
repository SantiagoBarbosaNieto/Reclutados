using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour {
    
    public GameObject optionsMenu;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
    }
}
