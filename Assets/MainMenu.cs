using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
