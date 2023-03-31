using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    public static PrefsManager Instance {get; private set;}
    public const string MONEY = "money";
    public const string EVENT_HAPPENED = "event_happened";
    public const string COLLABORATION = "collaboration";
    public const string ENDBRANCH = "endBranch";
    public const string TODAYSALES = "todaySales";
    public const string DAY = "dia";
    public const string NUMEVENTS = "_events";
    public const string NAME_EVENT = "_event_name_";
    public const string VALUE_EVENT = "_event_value_";



    private void Start() {
        ResetPrefs();
    }

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

    //Updates the amount of money the player has
    public void AddMoney(float money) {

        PlayerPrefs.SetFloat(MONEY, GetMoney() + money);
    }

    public float GetMoney()
    {
        return PlayerPrefs.GetFloat(MONEY);
    }
    public void UpdateMoney(float money) {
        PlayerPrefs.SetFloat(MONEY, PlayerPrefs.GetFloat(MONEY) + money);
    }

    //Updates value of event_happened
    public void eventHappendedTrue() {

        PlayerPrefs.SetInt(EVENT_HAPPENED, 1);
    }

    public void eventHappendedFalse() {

        PlayerPrefs.SetInt(EVENT_HAPPENED, 0);
    }

    public int getEventHappended() {
        return PlayerPrefs.GetInt(EVENT_HAPPENED);
    }
    
    //Updates the amount of times the player has collaborated with the guerrilla
    public void UpdateCollaboration(int collaboration) {
        PlayerPrefs.SetInt(COLLABORATION, GetCollaboration() + collaboration);
    }

    public int GetCollaboration()
    {
        return PlayerPrefs.GetInt(COLLABORATION);
    }

    //Updates the ending branch that the player will go to
    public void UpdateEndBranch(int endBranch) {
        PlayerPrefs.SetInt(ENDBRANCH, endBranch);
    }

    public int GetEndBranch()
    {
        return PlayerPrefs.GetInt(ENDBRANCH);
    }

    public void SetDay(int day)
    {
        PlayerPrefs.SetInt(DAY, day);
    }

    public void AdvanceDay()
    {
        PlayerPrefs.SetInt(DAY, GetDay()+1);
    }

    public int GetDay()
    {
        return PlayerPrefs.GetInt(DAY);
    }

    public void AddEvent(int day, string eventName, float eventValue)
    {
        int num = GetNumEvents(day);
        PlayerPrefs.SetInt(day+NUMEVENTS, num+1);
        PlayerPrefs.SetString(day+NAME_EVENT+num, eventName);
        PlayerPrefs.SetFloat(day+VALUE_EVENT+num, eventValue);
    }
    public void AddEvent( string eventName, float eventValue)
    {
        int day = GetDay();
        AddEvent(day, eventName, eventValue);
    }

    public int GetNumEvents(int day)
    {
        return PlayerPrefs.GetInt(day+NUMEVENTS);
    }

    public string GetEventName(int day, int num)
    {
        return PlayerPrefs.GetString(day+NAME_EVENT+num);
    }

    public float GetEventValue(int day, int num)
    {
        return PlayerPrefs.GetFloat(day+VALUE_EVENT+num);
    }

    public (string,float) GetEvent(int day, int num)
    {
        string name = GetEventName(day, num);
        float value = GetEventValue(day, num);

        return (name, value);
    }

    public List<(string,float)> GetEvents(int day)
    {
        List<(string,float)> events = new List<(string, float)>();

        int numEvents = GetNumEvents(day);
        for( int i = 0; i < numEvents; i++)
        {
            events.Add(GetEvent(day, i));
        }

        return events;
    }

    public void AddSalesMoney(float value)
    {
        PlayerPrefs.SetFloat(TODAYSALES, GetSalesMoney()+value);
    }

    public void SetSalesMoney(float value)
    {
        PlayerPrefs.SetFloat(TODAYSALES, value);
    }

    public float GetSalesMoney()
    {
        return PlayerPrefs.GetFloat(TODAYSALES);
    }

    //Adds a transition item to the back of the 
    public void AddTransitionItem(TransitionItem transitionItem) {
        int day = transitionItem.day;
        string desc = transitionItem.description;
        int id = PlayerPrefs.GetInt(day+NUMEVENTS); //The id in TransitionItem gets ignored whoops.
        float money = transitionItem.money;

        PlayerPrefs.SetString(day+NAME_EVENT+id, desc);
        PlayerPrefs.SetFloat(day+VALUE_EVENT+id, money);
        PlayerPrefs.SetInt(day+NUMEVENTS, PlayerPrefs.GetInt(day+"_events")+1);
    }

    public void ResetPrefs() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(EVENT_HAPPENED, 0);
        PlayerPrefs.SetFloat(MONEY, 0);
        PlayerPrefs.SetFloat(COLLABORATION, 0);
        PlayerPrefs.SetFloat(ENDBRANCH, 0);
        PlayerPrefs.SetFloat(TODAYSALES, 0);
        PlayerPrefs.SetInt(DAY, 1);
        PlayerPrefs.SetInt("1_events", 0);
    }

    public void StartNewDay() {
        PlayerPrefs.SetInt(EVENT_HAPPENED, 0);
        SetSalesMoney(0);
        AdvanceDay();
        PlayerPrefs.SetInt(GetDay() + "_events", 0);
    }

}
