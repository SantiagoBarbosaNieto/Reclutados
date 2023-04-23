using TMPro;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using System.Runtime.Serialization.Formatters.Binary;

public class GameLoader : MonoBehaviour {
    public string saveDirectory = "Saves";
    public string saveName = "savedGame";
    public GameObject notificationObject;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationContent;

    [SerializeField]
    private DaySO day1;
    [SerializeField]
    private DaySO day2;
    [SerializeField]
    private DaySO day3;
    [SerializeField]
    private DaySO day4;
    [SerializeField]
    private DaySO day5;
    [SerializeField]
    private DaySO day6;

    
    [SerializeField]
    private LoadDayRequestGameEvent loadDay;
    
    public void LoadFromFile() {

        string path = saveDirectory + "/" + saveName + ".bin";
        bool gameLoaded = true;
        LoadDayRequest request;

        Debug.Log("LOADING DATA...");

        if(!File.Exists(path)) {
            notificationTitle.text = "Error al cargar partida";
            notificationContent.text = "No se encuentra ninguna partida en el sistema";
            notificationObject.gameObject.SetActive(true);
        }
        else {
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream saveFile = File.Open(path, FileMode.Open);
                SaveGameData loadData = (SaveGameData) formatter.Deserialize(saveFile);

                saveFile.Close();

                switch (loadData.day) {
                    case 1:
                        Debug.Log("Attempting to load day 1... ");
                        request = new LoadDayRequest(day1);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 1 loaded!");
                        break;
                    
                    case 2:
                    Debug.Log("Attempting to load day 2... ");
                        request = new LoadDayRequest(day2);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 2 loaded!");
                        break;
                    
                    case 3:
                        Debug.Log("Attempting to load day 3... ");
                        request = new LoadDayRequest(day3);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 3 loaded!");
                        break;

                    case 4:
                        Debug.Log("Attempting to load day 4... ");
                        request = new LoadDayRequest(day4);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 4 loaded!");
                        break;

                    case 5:
                        Debug.Log("Attempting to load day 5... ");
                        request = new LoadDayRequest(day5);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 5 loaded!");
                        break;

                    case 6:
                        Debug.Log("Attempting to load day 6... ");
                        request = new LoadDayRequest(day6);
                        PrefsManager.Instance.ResetPrefs();
                        loadDay.Raise(request);
                        Debug.Log("Day 6 loaded!");
                        break;

                    default:
                        Debug.Log("Loading error: Day not found");
                        gameLoaded = false;
                        break;
                }

                PrefsManager.Instance.UpdateMoney(loadData.money);
                PrefsManager.Instance.SetDay(loadData.day);
                PrefsManager.Instance.UpdateEndBranch(loadData.endBranch);
                PrefsManager.Instance.UpdateCollaboration(loadData.collaboration);

                Debug.Log("~~~ LOADED GAME DATA ~~~");
                Debug.Log("MONEY: " + PrefsManager.Instance.GetMoney());
                Debug.Log("COLLABORATION: " + PrefsManager.Instance.GetCollaboration());
                Debug.Log("END_BRANCH: " + PrefsManager.Instance.GetEndBranch());
                Debug.Log("DAY: " + PrefsManager.Instance.GetDay());
                
            }
            catch {
                notificationTitle.text = "Error al cargar partida";
                notificationContent.text = "No fue posible cargar la partida";
                notificationObject.gameObject.SetActive(true);
                throw;
            }
        }
    }
}
