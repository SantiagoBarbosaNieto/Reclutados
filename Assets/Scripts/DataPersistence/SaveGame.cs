using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour {
    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public SaveGameData saveGameData;
    public GameObject notificationObject;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationContent;

    public void SaveToFile() {

        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        saveGameData.day = PrefsManager.Instance.GetDay();
        saveGameData.money = PrefsManager.Instance.GetMoney();
        saveGameData.endBranch = PrefsManager.Instance.GetEndBranch();
        saveGameData.collaboration = PrefsManager.Instance.GetCollaboration();

        try {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");
            formatter.Serialize(saveFile, saveGameData);
            saveFile.Close();
            print("Game Saved to " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");

            notificationTitle.text = "Partida guardada";
            notificationContent.text = Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin";
            notificationObject.gameObject.SetActive(true);
        }
        catch {

            notificationTitle.text = "Error al guardar partida";
            notificationContent.text = "No se pudo guardar la partida en el sistema";
            notificationObject.gameObject.SetActive(true);

            throw;
        }

    }
}
