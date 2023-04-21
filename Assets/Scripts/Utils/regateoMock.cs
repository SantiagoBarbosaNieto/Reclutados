using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regateoMock : MonoBehaviour
{

    void Awake()
    {  
        int randInt = Random.Range(-30, 70);
        int day = PlayerPrefs.GetInt("day");
        int numEvents = PlayerPrefs.GetInt(day+"_events")+1;
        Debug.Log("Num dia: " +  day + "   Num events: " + numEvents);
        PlayerPrefs.SetString(day+"_event_name_"+numEvents, "Venta del día");
        PlayerPrefs.SetInt(day+"_event_value_"+numEvents, randInt);
        PlayerPrefs.SetInt(day+"_events", numEvents);

        transform.GetComponent<TMPro.TextMeshProUGUI>().text = "Resultado de las ventas de hoy: " + randInt +"$";

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
