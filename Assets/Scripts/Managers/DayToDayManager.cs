using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DayToDayManager : MonoBehaviour
{
    private int index = 0;
    public List<DaySO> dayProgression;
    public LoadDayRequestGameEvent loadDayRequestGameEvent;

    private void Start() {
        LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
        PrefsManager.Instance.ResetPrefs();
    }

    public void StartNewDay() {
        index += 1;
        if (index < dayProgression.Count) {
            LoadDayRequest request = new LoadDayRequest(dayProgression[index]);
            PrefsManager.Instance.StartNewDay();
            loadDayRequestGameEvent.Raise(request);
        } else {
            Debug.Log("No hay mas dias para cargar: Aca se debe cargar uno de los finales");
        }
        
    }
}
