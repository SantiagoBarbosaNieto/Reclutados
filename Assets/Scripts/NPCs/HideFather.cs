using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFather : MonoBehaviour {
    
    [Header("Dependencies")]
    public SpriteRenderer spriteRenderer;

    void Start() {
        int day =  GameStateManager.Instance._dia;
        if(day == 2 || day == 4 || day >= 6) {
            spriteRenderer.enabled = false;
        } else {
            spriteRenderer.enabled = true;
        }
    }
}
