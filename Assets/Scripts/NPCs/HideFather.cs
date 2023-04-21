using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFather : MonoBehaviour {
    
    [Header("Dependencies")]
    public SpriteRenderer spriteRenderer;

    void Start() {
        if(PrefsManager.Instance.GetDay() == 2 || PrefsManager.Instance.GetDay() == 4 || PrefsManager.Instance.GetDay() >= 6) {
            spriteRenderer.enabled = false;
        } else {
            spriteRenderer.enabled = true;
        }
    }
}
