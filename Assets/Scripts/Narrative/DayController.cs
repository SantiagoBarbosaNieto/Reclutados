using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DayController : MonoBehaviour
{
    [SerializeField]
    public LoadDialogSceneRequestGameEvent LoadDialogSceneRequest;
    public LoadSceneRequestGameEvent LoadLevelRequest;

    private int dayNumber;

    //There should be a Queue here for info scenes

    //This queue will create 
    Queue<LoadDialogSceneRequest> greeting;

    //After the greeting the player is thrown into the overworld. The
    //details of where should be in the load request which means there may
    //have to be a LoadLevelSceneRequest in the near future
    LoadSceneRequest level;

    //Another dialog progression system will take care of the sales until
    //The sales system is in place
    Queue<LoadDialogSceneRequest> sales;

    Queue<LoadDialogSceneRequest> dayEnd;

    //In the end of the day, the results will be shown
    LoadSceneRequest transition;

    private bool dayLoaded = false;

    public void OnLoadDay(LoadDayRequest request) {
        Debug.Log("Day loaded successfully");
        DaySO day = request.day;
        greeting = new Queue<LoadDialogSceneRequest>(day.greeting);
        level = day.level;
        sales = new Queue<LoadDialogSceneRequest>(day.sales);
        dayEnd = new Queue<LoadDialogSceneRequest>(day.dayEnd);
        transition = day.transition;
        LoadOptionalScenes();
        dayLoaded = true;
        Advance();
    }

    //This method is meant to load the optional dialogs that are added through the players desitions
    //How the system to queue these optional scenes will work is still yet to be decided.
    private void LoadOptionalScenes() {
        
    }



    //Will change the scene to the next one
    public void Advance() {
        if(!dayLoaded) {
            Debug.LogError("The day has not been loaded yet");
            return;
        }

        LoadSceneRequest currentRequest;

        if(greeting.Count != 0) {
            currentRequest = greeting.Dequeue();
        }
        else if(level != null) {
            currentRequest = level;
            level = null;
        }
        else if(sales.Count != 0){
            currentRequest = sales.Dequeue();
        }
        else if(dayEnd.Count != 0) {
            currentRequest = dayEnd.Dequeue();
        }
        else if(transition != null) {
            currentRequest = transition;
        }
        else { //Fin del dia
            //Raise game event to go to the next day
            return;
        }

        //If the scene is a dialog scene
        if(currentRequest.GetType() == typeof(LoadDialogSceneRequest)) {
            LoadDialogSceneRequest.Raise(currentRequest as LoadDialogSceneRequest);
        }
        else if(currentRequest.GetType() == typeof(LoadSceneRequest)) {
            LoadLevelRequest.Raise(currentRequest);
        }
        
    }

}
