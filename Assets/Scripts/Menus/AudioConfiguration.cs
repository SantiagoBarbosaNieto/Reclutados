// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using UnityEngine.UI;

public class AudioConfiguration : MonoBehaviour {

    public Slider volumeSlider;
    void Start() {
        volumeSlider.value = AudioListener.volume;
     
    }
 
    public void ChangeVol() {
        AudioListener.volume = volumeSlider.value;
    }
}
