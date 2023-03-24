using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    public static PrefsManager Instance {get; private set;}
    public const string MONEY = "money";
    public const string COLLABORATION = "collaboration";
    public const string ENDBRANCH = "endBranch";

    public const string REGATEO_MONEY = "regMoney";
    public const string DAY = "dia";

    public const string NUMEVENTS = "_events";

    public const string NAME_EVENT = "_event_name_";
    public const string VALUE_EVENT = "_event_value_";


    private void Start() {
        PlayerPrefs.SetFloat(MONEY, 0);
        PlayerPrefs.SetFloat(REGATEO_MONEY, 0);
        PlayerPrefs.SetFloat(COLLABORATION, 0);
        PlayerPrefs.SetFloat(ENDBRANCH, 0);
    }

    //Updates the amount of money the player has
    public void AddMoney(float money) {

        PlayerPrefs.SetFloat(MONEY, GetMoney() + money);
    }

    public float GetMoney()
    {
        return PlayerPrefs.GetFloat(MONEY);
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
        int num = GetNumEvents(day) +1;
        PlayerPrefs.SetInt(day+NUMEVENTS, num);
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

    public void AddRegateoMoney(float value)
    {
        PlayerPrefs.SetFloat(REGATEO_MONEY, GetRegateoMoney()+value);
    }

    public void SetRegateoMoney(float value)
    {
        PlayerPrefs.SetFloat(REGATEO_MONEY, value);
    }

    public float GetRegateoMoney()
    {
        return PlayerPrefs.GetFloat(REGATEO_MONEY);
    }
}
