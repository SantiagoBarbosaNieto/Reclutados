using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class HelpMenuSlideshow : MonoBehaviour {

    public Sprite[] images; // Arreglo de imágenes
    private int currentImageIndex = 0; // Índice de la imagen actual

    void Start() {
        GetComponent<Image>().sprite = images[currentImageIndex]; // Mostrar la primera imagen en pantalla al inicio
        Debug.Log("START");
    }

    public void Next() {
        currentImageIndex += 1;
        if(currentImageIndex > images.Length-1) {
            currentImageIndex = 0;
        }
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

    public void Previous() {
        currentImageIndex -= 1;
        if(currentImageIndex < 0) {
            currentImageIndex = images.Length-1;
        }
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

    public void ResetSlides() {
        currentImageIndex = 0;
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

}
