using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFather : MonoBehaviour {
    
    [Header("Dependencies")]
    public GameObject father;

    void Start() {
        int day =  GameStateManager.Instance._dia;
        if(day == 2 || day == 4 || day >= 6) {
            father.gameObject.SetActive(false);
        } else {
            father.gameObject.SetActive(true);
        }
    }
}
