using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class GameLoader : MonoBehaviour {
    public string saveDirectory = "Saves";
    public string saveName = "savedGame";
    public GameObject notificationObject;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationContent;
    
    public void LoadFromFile() {

        string path = saveDirectory + "/" + saveName + ".bin";

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

                Debug.Log("~~~ LOADED GAME DATA ~~~");
                Debug.Log("MONEY: " + loadData.money);
                Debug.Log("COLLABORATION: " + loadData.collaboration);
                Debug.Log("END_BRANCH: " + loadData.endBranch);
                Debug.Log("DAY: " + loadData.day);

                PrefsManager.Instance.UpdateMoney(loadData.money);
                PrefsManager.Instance.SetDay(loadData.day);
                PrefsManager.Instance.UpdateEndBranch(loadData.endBranch);
                PrefsManager.Instance.UpdateCollaboration(loadData.collaboration);

                
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
