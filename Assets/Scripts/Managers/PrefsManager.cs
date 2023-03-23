using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    public const string MONEY = "money";
    public const string COLLABORATION = "collaboration";
    public const string ENDBRANCH = "endBranch";


    private void Start() {
        PlayerPrefs.SetFloat(MONEY, 0);
        PlayerPrefs.SetFloat(COLLABORATION, 0);
        PlayerPrefs.SetFloat(ENDBRANCH, 0);
    }

    //Updates the amount of money the player has
    public void UpdateMoney(float money) {
        

        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + money);
    }

    //Updates the amount of times the player has collaborated with the guerrilla
    public void UpdateCollaboration(int collaboration) {
        PlayerPrefs.SetInt("collaboration", PlayerPrefs.GetInt("collaboration") + collaboration);
    }

    //Updates the ending branch that the player will go to
    public void UpdateEndBranch(int endBranch) {
        PlayerPrefs.SetInt("endBranch", endBranch);
    }
}
