using UnityEngine;

public class TagParser : MonoBehaviour
{

    private const string PREF = "pref";
    private const string REGATEO = "reg";
    private const string DP = "dp";

    public static void ParseTag(string tag) {
        string[] splitTag = tag.Split(" ");
            
        string command = splitTag[0];
        string key = splitTag[1];
        string value = splitTag[2];

        if(command == PREF) {
            switch(key) {
                case "money":
                    if(EventManager.Instance != null) {
                        Debug.Log("Add money tag parsed");
                        EventManager.Instance.AddMoney(float.Parse(value));
                    }
                    break;
                
                case "collaboration":
                    if(EventManager.Instance != null)  {
                        EventManager.Instance.IncreaseCollaboration();
                    }
                    break;

                case "endBranch":
                    if(EventManager.Instance != null) {
                        EventManager.Instance.EndBranch(int.Parse(value));
                    }
                    break;
                default:
                    Debug.LogError("Key " + key + " is not defined under pref tag");
                    break;
            }
        }
        else if (command == REGATEO)
        {
             switch(key) {
                case "compra":
                    Debug.Log("Compa de " + value + " unidades registrada");
                    PrefsManager.Instance.AddRegateoMoney(float.Parse(value));
                    break;
                default:
                    Debug.LogError("Key " + key + " is not defined under pref tag");
                    break;
            }
        }

        else if(command == DP) {



        } 

    }

}
