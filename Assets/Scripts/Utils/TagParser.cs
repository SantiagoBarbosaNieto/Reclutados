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
    public AddMoneyGameEvent addMoneyGameEvent;

    [SerializeField]
    public DialogEventGameEvent addOptionalDialogGameEvent;

    private const string PREF = "pref";
    private const string REGATEO = "reg";
    private const string DP = "dp";

    private const string PLAY = "play";

    private const string STOP = "stop";

    public void ParseTag(string tag) {
        string[] splitTag = tag.Split(" ");
       

        if(splitTag.Length < 1)
        {
            Debug.Log("Se intentó leer un TAG no válido: " + tag);
            return;
        }
            
        string command = splitTag[0];

        if(command == PREF) {
            string key = splitTag[1];
            string value = splitTag[2];
            if(splitTag.Length != 3) {
                Debug.Log("The tag is not properly formatted");
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
                    Debug.Log("Key " + key + " is not defined under pref tag");
                    break;
            }
        }
        else if (command == REGATEO)
        {
            string key = splitTag[1];
            string value = splitTag[2];
             switch(key) {
                case "compra":
                    Debug.Log("Compa de " + value + " unidades registrada");
                    AddMoney eventInfo = new AddMoney(float.Parse(value), "Compra", true);
                    addMoneyGameEvent.Raise(eventInfo);
                    break;
                default:
                    Debug.Log("Key " + key + " is not defined under pref tag");
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

        //play [looped?] [continuous?] [sound]
        //Plays @sound either oneshot or looped. 
        //If continuous is true, the audio will play from the AudioManager meaning that it will continue playing even after the object parent is destroyed. Must use "stop" command in order to stop it
        //If continuous is false, the audio will be instantiated in the parent and will go away once the parent is destroyed

        else if(command == PLAY) {
            if(splitTag.Length != 4) {
                Debug.Log("The tag is not properly formatted");
            }
            string looped = splitTag[1];
            string continuous = splitTag[2];
            string sound = splitTag[3];

            Debug.Log("Attempting to play: " + sound);

            //TODO finish PLAY and STOP
            try {

                bool isContinuous = bool.Parse(continuous);
                bool isLooped = bool.Parse(looped);
                AudioClip clip = Resources.Load("SFX/" + sound) as AudioClip;

                if (clip == null) {
                    Debug.Log("The clip " + "SFX/" + sound + " was not found");
                }

                if(isContinuous) {

                    Debug.Log("Attempting to play from audio manager");
                    if(AudioManager.Instance != null) {
                        if(isLooped) 
                            AudioManager.Instance.PlaySoundLooped(clip);
                        else 
                            AudioManager.Instance.PlaySound(clip);
                    }
                }
                else {
                    AudioSource.PlayClipAtPoint(clip, transform.position);
                }

            } catch (FormatException) {
                Debug.Log("The tag is not properly formatted: continuous must be a bool");
            } catch (Exception) {
                Debug.Log("There was an error loading the audio clip: " + sound);
            }
        }

        else if(command == STOP) {
            if(AudioManager.Instance != null) {
                AudioManager.Instance.StopSound();
            }
        }

        else {
            Debug.Log("The command " + command + " is not defined");
            return;
        }

    }

}
