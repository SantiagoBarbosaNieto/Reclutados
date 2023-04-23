using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DayToDayManager : MonoBehaviour
{
    private int index = 0;
    public List<DaySO> dayProgression;
    public LoadDayRequestGameEvent loadDayRequestGameEvent;
    public GameEvent nextDayGameStateEvent;
    public GameEvent resetGameStateEvent;

    private void Start() {
        LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
        //PrefsManager.Instance.ResetPrefs();
        resetGameStateEvent.Raise();
    }

    public void ResetDayProgression()
    {
        index = 0;
        LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
        //PrefsManager.Instance.ResetPrefs();
        resetGameStateEvent.Raise();
        loadDayRequestGameEvent.Raise(request);
    }

    public void NextDay() {
        index += 1;
        if (index < dayProgression.Count) {
            LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
            //PrefsManager.Instance.StartNewDay();
            nextDayGameStateEvent.Raise();
            loadDayRequestGameEvent.Raise(request);
        } else {
            Debug.Log("No hay mas dias para cargar: Aca se debe cargar uno de los finales");
        }
        
    }
}
