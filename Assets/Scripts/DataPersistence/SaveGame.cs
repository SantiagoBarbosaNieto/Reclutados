using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour {
    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public SaveGameData saveGameData;

    public void SaveToFile() {

        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        saveGameData.day = PrefsManager.Instance.GetDay();
        saveGameData.money = PrefsManager.Instance.GetMoney();
        saveGameData.endBranch = PrefsManager.Instance.GetEndBranch();
        saveGameData.collaboration = PrefsManager.Instance.GetCollaboration();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");
        formatter.Serialize(saveFile, saveGameData);

        saveFile.Close();

        print("Game Saved to " + Directory.GetCurrentDirectory().ToString() + "/Saves/" + saveName + ".bin");
    }
}
