using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public string saveDirectory = "Saves";
    public string saveName = "savedGame";
    
    public void LoadFromFile() {

        Debug.Log("LOADING DATA...");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(saveDirectory + "/" + saveName + ".bin", FileMode.Open);
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
}
