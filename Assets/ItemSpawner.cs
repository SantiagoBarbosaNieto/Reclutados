using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Object itemPrefab;
    public Transform content;
    public Transform valueObject;
    public Transform numDia; 

    void Awake() 
    {

        int day = PlayerPrefs.GetInt("day");
        numDia.GetComponent<TMPro.TextMeshProUGUI>().text = ""+day;
        int numEvents = PlayerPrefs.GetInt(day+"_events");
        int total = 0;
        for(int i = 0; i < numEvents; i++)
        {
            string name = PlayerPrefs.GetString(day+"_event_name_"+i);
            int value = PlayerPrefs.GetInt(day+"_event_value_"+i);
            total += value;

            GameObject item = Instantiate (itemPrefab) as GameObject;
            item.transform.SetParent( content);
            item.GetComponent<ItemInitialize>().SetName(name);
            item.GetComponent<ItemInitialize>().SetValue(value);
            item.transform.localScale = new Vector3(1,1,1);
        }

        TMPro.TextMeshProUGUI  TMvalue = valueObject.GetComponent<TMPro.TextMeshProUGUI>();

        TMvalue.text = "$ "  + (total >= 0 ? " " : "") + total.ToString();

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
