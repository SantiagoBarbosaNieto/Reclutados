using UnityEngine;

public class TagParser : MonoBehaviour
{

    private const string PREF = "pref";
    private const string REGATEO = "reg";
    private const string DP = "dp";

    public static void ParseTag(string tag) {
        string[] splitTag = tag.Split(" ");
        if(splitTag.Length != 3 && splitTag.Length != 4) {
            Debug.LogError("The tag is not properly formatted");
            return;
        }

        if(splitTag.Length < 3)
        {
            Debug.Log("Se intentó leer un TAG no válido: " + tag);
            return;
        }
            
        string command = splitTag[0];
        string key = splitTag[1];
        string value = splitTag[2];

        if(command == PREF) {
            if(splitTag.Length != 3) {
                Debug.LogError("The tag is not properly formatted");
                return;
            }
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
                    PrefsManager.Instance.AddSalesMoney(float.Parse(value));
                    break;
                default:
                    Debug.LogError("Key " + key + " is not defined under pref tag");
                    break;
            }
        }

        else if(command == DP) {
            
        } 

        else {
            Debug.LogError("The command " + command + " is not defined");
            return;
        }

    }

}
