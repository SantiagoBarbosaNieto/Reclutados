using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class HelpMenuSlideshow : MonoBehaviour {

    public Sprite[] images; // Arreglo de imágenes
    public int minIndex;
    public int maxIndex;
    private int currentImageIndex = 0; // Índice de la imagen actual

    void Start() {

        if(maxIndex > images.Length - 1) {
            maxIndex = images.Length - 1;
        }

        if(minIndex < 0) {
            minIndex = 0;
        }
        
        currentImageIndex = minIndex;

        GetComponent<Image>().sprite = images[currentImageIndex]; // Mostrar la primera imagen en pantalla al inicio
        Debug.Log("START");
    }

    public void Next() {
        currentImageIndex += 1;
        if(currentImageIndex > maxIndex) {
            currentImageIndex = minIndex;
        }
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

    public void Previous() {
        currentImageIndex -= 1;
        if(currentImageIndex < minIndex) {
            currentImageIndex = maxIndex;
        }
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

    public void ResetSlides() {
        currentImageIndex = minIndex;
        GetComponent<Image>().sprite = images[currentImageIndex];
    }

}
