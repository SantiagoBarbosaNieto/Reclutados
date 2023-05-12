using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using System;
using TMPro;

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

    public GameObject menuManager;

    private int dayNumber;

    [SerializeField]
    private SceneSO regateoScene;

    public GameObject endScreenPrefab;

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

    DaySO day;

    private bool dayLoaded = false;

    public void OnLoadDay(LoadDayRequest request) {
        day = request.day;
        Debug.Log("DayController: Loading day " + day.number);
        if(day.regateoDayCharacters.Count > 0)
            GameStateManager.Instance.SetCurrentDayCharacters(day.regateoDayCharacters);
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
            if(day.number == 1)
                menuManager.GetComponent<HelpMenu>().OpenMenuFiltered(0,1);
        }
        //Sales DP list
        else if(sales.Count != 0){
            Debug.Log("sales");
            currentRequest = sales.Dequeue();
        }
        //Regateo Scene
        else if(regateo != null && regateo.scene != null && day.regateoActive) {
            currentRequest = regateo;
            regateo = null;
            if(day.number == 1)
                menuManager.GetComponent<HelpMenu>().OpenMenuFiltered(2,5);
        }
        else if(dayEnd.Count != 0) {
            Debug.Log("dayEnd");
            currentRequest = dayEnd.Dequeue();
        }
        else if(transition != null && transition.scene != null) {
            enableUIEvent.Raise(false);
            if(day.regateoActive) {
                AddMoney eventInfo = new AddMoney(GameStateManager.Instance.GenerateDayExpenses(day.baseMoneyLossPercentage), "Mercancía no vendida");
                addMoneyEvent.Raise(eventInfo);
            }
            foreach(InfoExpense i in day.expenses) {
                AddMoney eventInfo = new AddMoney(i.money, i.description);
                addMoneyEvent.Raise(eventInfo);
            }
            currentRequest = transition;
            if(day.number == 1)
                menuManager.GetComponent<HelpMenu>().OpenMenuFiltered(6,6);
        }
        else { //Fin del juego
            //Raise game event to go to the next day
            if(day.number == 8)
            {

                var x = Instantiate(endScreenPrefab);
                TextSceneController te = x.GetComponent<TextSceneController>();
                te.debugText = "Muchos niños tuvieron que pasar por lo que tuvo que pasar Juanito. Algunos fueron valientes y se resistieron a la guerrilla, pero como resultado muchos tuvieron terribles dificultades y muchos también fueron asesinados junto con sus familias. Otros niños decidieron unirse a la guerrilla: quizás por necesidad, algunos por engaño, otros por odio hacia los otros bandos. Muchos de ellos murieron por una causa en la que no creían, otros lograron mejorar sus condiciones de vida, pero fueron discriminados después de que se firmara la paz en el país, otros fueron forzados a cometer actos horribles.";
                te.exit.onClick.RemoveAllListeners();
                te.exit.onClick.AddListener(() => {
                    #if UNITY_STANDALONE
                        Application.Quit();
                    #endif
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                });
                te.exit.GetComponentInChildren<TMP_Text>().text = "Fin";
            }
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
