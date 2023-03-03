using System.Collections;
using System.Collections.Generic;
// Uniti Engine
using UnityEngine;
//using UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

    }
    public void Exit()
    {
        UnityEngine.Debug.Log("Salir...");
        Application.Quit();
    }

}
