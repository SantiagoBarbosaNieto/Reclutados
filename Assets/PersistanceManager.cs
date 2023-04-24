using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

using System.IO;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class PersistanceManager : MonoBehaviour
{
    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public SaveGameData saveGameData;

    //Events
    
    [SerializeField]
    private IntGameEvent loadDay;

    [SerializeField]
    private NotificationContentGameEvent udpateAndShowNotificationEvent;

    
    public void SaveToFile() {

        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        saveGameData.day = GameStateManager.Instance._dia;
        saveGameData.money = GameStateManager.Instance._moneyDayStart; //Se guarda solo la plata al inicio del día para evitar el exploit de que gane plata y antes de acabar el día guarde y vuelva a cargar la partida (lo que reinicia ese dia)
        saveGameData.endBranch = GameStateManager.Instance._endBranch;
        saveGameData.collaboration = GameStateManager.Instance._collaborations;

        try {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");
            formatter.Serialize(saveFile, saveGameData);
            saveFile.Close();
            print("Game Saved to " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");
            NotificationContent eventInfo = new NotificationContent("Partida guardada", Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");

            udpateAndShowNotificationEvent.Raise(eventInfo);
        }
        catch {

            NotificationContent eventInfo = new NotificationContent("Error al guardar partida", "No se pudo guardar la partida en el sistema");

            udpateAndShowNotificationEvent.Raise(eventInfo);

            throw;
        }

    }

    public void LoadFromFile()
    {
        string path = directoryName + "/" + saveName + ".bin";

        Debug.Log("LOADING FILE...");

        if(!File.Exists(path)) {
            
            NotificationContent eventInfo = new NotificationContent("Error al cargar partida", "No se encuentra ninguna partida guardada en el sistema");

            udpateAndShowNotificationEvent.Raise(eventInfo);
        }
        else {
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream saveFile = File.Open(path, FileMode.Open);
                SaveGameData loadData = (SaveGameData) formatter.Deserialize(saveFile);
                saveFile.Close();

                int dia = loadData.day;
                float money = loadData.money;
                int endBranch = loadData.endBranch;
                int collaboration = loadData.collaboration;

                Debug.Log("Attempting to load day "+dia+"... ");
                loadDay.Raise(dia);
                Debug.Log("Attempting to load day "+dia+"... ");
                if(GameStateManager.Instance._isDayLoaded)
                {
                    Debug.Log("Day "+dia+" loaded!");
                }
                else
                {
                    NotificationContent eventInfo = new NotificationContent("Error al cargar partida", "No existe el día "+dia+" en el sistema:  LOADDAYBOOL:" + GameStateManager.Instance._isDayLoaded);

                    udpateAndShowNotificationEvent.Raise(eventInfo);
                    return;
                }


                Debug.Log("Loading saved game data...");
                GameStateManager.Instance.SetMoneyDayStart(money);
                GameStateManager.Instance.SetDia(dia);
                GameStateManager.Instance.SetEndBranch(endBranch);
                GameStateManager.Instance.SetCollaborations(collaboration);

                Debug.Log("~~~ LOADED GAME DATA ~~~");
                Debug.Log("MONEY: " + GameStateManager.Instance.GetTotalMoney());
                Debug.Log("COLLABORATION: " + GameStateManager.Instance._collaborations);
                Debug.Log("END_BRANCH: " + GameStateManager.Instance._endBranch);
                Debug.Log("DAY: " + GameStateManager.Instance._dia);
                
            }
            catch {
                NotificationContent eventInfo = new NotificationContent("Error al cargar partida", "No fue posible cargar la partida, el archivo tiene información inválida o corrupta");

                udpateAndShowNotificationEvent.Raise(eventInfo);
                return;
            }
        }
    }
}
