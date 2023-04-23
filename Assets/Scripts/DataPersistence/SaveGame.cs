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
