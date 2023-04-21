using UnityEngine;
using System;
using ScriptableObjectArchitecture;

public class TagParser : MonoBehaviour
{
    public static TagParser Instance {get; private set;}

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

    [SerializeField]
    public DialogEventGameEvent addOptionalDialogGameEvent;

    private const string PREF = "pref";
    private const string REGATEO = "reg";
    private const string DP = "dp";

    public void ParseTag(string tag) {
        string[] splitTag = tag.Split(" ");
       

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
            if(splitTag.Length != 4){
                Debug.Log("The tag is not properly formatted");
                return;
            }
            string dp = splitTag[1];
            string queue = splitTag[2];
            string day = splitTag[3];

            try {
                int parsedDay = int.Parse(day);
                DialogProgressionSO loadedDp = Resources.Load("OptionalEvents/" + dp + "/" + dp) as DialogProgressionSO;
                if(loadedDp == false) {
                    throw new Exception();
                }

                DialogEvent dialogEvent = new DialogEvent(parsedDay, queue, loadedDp);
                addOptionalDialogGameEvent.Raise(dialogEvent);
            } catch(FormatException) {
                Debug.Log("The tag is not properly formatted: the day must be an int");
            } catch(Exception) {
                Debug.LogError("There was an error loading the Dialog progression: " + dp);
            }
            
        } 

        else {
            Debug.LogError("The command " + command + " is not defined");
            return;
        }

    }

}
