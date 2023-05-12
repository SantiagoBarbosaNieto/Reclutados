using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class HelpMenu : MonoBehaviour {

    public GameObject configurationObject;

    public void OpenMenu() {
        OpenMenuFiltered(0,configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().images.Length);
    }
    public void CloseMenu() {
        configurationObject.gameObject.SetActive(false);
    }

    public void OpenMenuFiltered(int min, int max)
    {
        if(min < 0)
            min = 0;
        if(max >= configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().images.Length)
            max = configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().images.Length;
        configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().minIndex = min;
        configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().maxIndex = max;
        configurationObject.gameObject.GetComponent<HelpMenuSlideshow>().ResetSlides();
        
        configurationObject.gameObject.SetActive(true);
    }

}
