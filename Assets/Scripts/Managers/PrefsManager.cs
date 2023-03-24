using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    public const string MONEY = "money";
    public const string COLLABORATION = "collaboration";
    public const string ENDBRANCH = "endBranch";
    public const string TODAYSALES = "todaySales";

    private void Start() {
        ResetPrefs();
    }

    //Updates the amount of money the player has
    public void UpdateMoney(float money) {
        PlayerPrefs.SetFloat(MONEY, PlayerPrefs.GetFloat(MONEY) + money);
    }

    public void UpdateDaySales(float money) {
        PlayerPrefs.SetFloat(TODAYSALES, PlayerPrefs.GetFloat(TODAYSALES) +  money);
    }

    //Updates the amount of times the player has collaborated with the guerrilla
    public void UpdateCollaboration(int collaboration) {
        PlayerPrefs.SetInt(COLLABORATION, PlayerPrefs.GetInt(COLLABORATION) + collaboration);
    }

    //Updates the ending branch that the player will go to
    public void UpdateEndBranch(int endBranch) {
        PlayerPrefs.SetInt(COLLABORATION, endBranch);
    }

    //Adds a transition item to the back of the 
    public void AddTransitionItem(TransitionItem transitionItem) {
        int day = transitionItem.day;
        string desc = transitionItem.description;
        int id = PlayerPrefs.GetInt(day+"_events"); //The id in TransitionItem gets ignored whoops.
        float money = transitionItem.money;

        PlayerPrefs.SetString(day+"_event_name_"+id, desc);
        PlayerPrefs.SetInt(day+"_event_value_"+id, (int)money);
        PlayerPrefs.SetInt(day+"_events", PlayerPrefs.GetInt(day+"_events")+1);
    }

    public void ResetPrefs() {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat(MONEY, 0);
        PlayerPrefs.SetFloat(COLLABORATION, 0);
        PlayerPrefs.SetFloat(ENDBRANCH, 0);
        PlayerPrefs.SetFloat(TODAYSALES, 0);
        PlayerPrefs.SetInt("day", 1);
        PlayerPrefs.SetInt("1_events", 0);
    }

    public void StartNewDay() {
        PlayerPrefs.SetFloat(TODAYSALES, 0);
        PlayerPrefs.SetInt("day", + PlayerPrefs.GetInt("day" + 1));
        PlayerPrefs.SetInt(PlayerPrefs.GetInt("day") + "_events", 0);
    }

}
