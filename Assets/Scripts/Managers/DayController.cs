using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DayController : MonoBehaviour
{
    [SerializeField]
    private SceneSO dialogScene;

    [SerializeField]
    DialogEventManager optionalDialogsManager;

    [SerializeField]
    public LoadDialogSceneRequestGameEvent LoadDialogSceneRequest;
    public LoadSceneRequestGameEvent LoadLevelRequest;

    public AddMoneyGameEvent addMoneyEvent;

    public BoolGameEvent updateIsDayLoadedEvent;

    public BoolGameEvent enableUIEvent;

    private int dayNumber;

    [SerializeField]
    private SceneSO regateoScene;

    //There should be a Queue here for info scenes

    //This queue will create 
    Queue<LoadDialogSceneRequest> greeting;

    //After the greeting the player is thrown into the overworld. The
    //details of where should be in the load request which means there may
    //have to be a LoadLevelSceneRequest in the near future
    LoadSceneRequest level;

    LoadSceneRequest regateo;

    //Another dialog progression system will take care of the sales until
    //The sales system is in place
    Queue<LoadDialogSceneRequest> sales;

    Queue<LoadDialogSceneRequest> dayEnd;

    //In the end of the day, the results will be shown
    LoadSceneRequest transition;

    private bool dayLoaded = false;

    public void OnLoadDay(LoadDayRequest request) {
        DaySO day = request.day;
        greeting = new Queue<LoadDialogSceneRequest>(day.greeting);
        level = day.level;
        sales = new Queue<LoadDialogSceneRequest>(day.sales);
        regateo = new LoadSceneRequest(regateoScene, false);
        dayEnd = new Queue<LoadDialogSceneRequest>(day.dayEnd);
        transition = day.transition;
        LoadOptionalScenes(day.number);
        dayLoaded = true;
        updateIsDayLoadedEvent.Raise(true);
        Advance();
        enableUIEvent.Raise(true);
        Debug.Log("Day " + day.number + " loaded successfully");
    }

    //This method is meant to load the optional dialogs that are added through the players desitions
    //How the system to queue these optional scenes will work is still yet to be decided.
    private void LoadOptionalScenes(int day) {
        Dictionary<int, List<DialogEvent>> optionalDialogEvents = optionalDialogsManager.optionalDialogEvents;
        if(optionalDialogEvents.ContainsKey(day)) {
            Debug.Log("DayController: New optional dialogs being added");
            List<DialogEvent> eventosOpcionalesDelDia = optionalDialogEvents[day];
            foreach(var evento in eventosOpcionalesDelDia) {
                string queue = evento.queue;
                DialogProgressionSO dp = evento.dp;

                LoadDialogSceneRequest loadRequest = new LoadDialogSceneRequest(dialogScene, false, dp);

                switch(queue) {
                    case "greeting":
                        greeting.Enqueue(loadRequest);
                        break;
                    case "sales":
                        sales.Enqueue(loadRequest);
                        break;
                    case "dayEnd":
                        dayEnd.Enqueue(loadRequest);
                        break;
                }
            }
        }
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
        else if(level != null && level.scene != null) {
            currentRequest = level;
            level = null;
        }
        //Sales DP list
        else if(sales.Count != 0){
            Debug.Log("sales");
            currentRequest = sales.Dequeue();
        }
        //Regateo Scene
        else if(regateo != null && regateo.scene != null) {
            currentRequest = regateo;
            regateo = null;
        }
        else if(dayEnd.Count != 0) {
            Debug.Log("dayEnd");
            currentRequest = dayEnd.Dequeue();
        }
        else if(transition != null && transition.scene != null) {
            enableUIEvent.Raise(false);
            AddMoney eventInfo = new AddMoney(-1.2f*GameStateManager.Instance._dia, "Gastos del día");
            addMoneyEvent.Raise(eventInfo);
            currentRequest = transition;
        }
        else { //Fin del dia
            //Raise game event to go to the next day
            Debug.Log("Aqui debe iniciar el siguiente día");
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
