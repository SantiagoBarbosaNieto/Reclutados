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

    public BoolGameEvent updateIsDayLoadedEvent;

    private void Start() {
        LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
        //PrefsManager.Instance.ResetPrefs();
        resetGameStateEvent.Raise();
    }

    public void ResetDayProgression()
    {
        LoadDay(1);
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

    public void LoadDay(int day) {
        updateIsDayLoadedEvent.Raise(false);
        index = day-1;
        if (index >= 0 && index < dayProgression.Count) {
            
            LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
            resetGameStateEvent.Raise();
            loadDayRequestGameEvent.Raise(request);
        } else {
            Debug.Log("No existe el día que se quiere cargar: " + day + " (index: " + index + ")");
        }
    }
}
