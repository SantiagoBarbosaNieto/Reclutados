using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Object itemPrefab;
    public Transform content;
    public Transform valueObject;
    public Transform numDia; 

    // Start is called before the first frame update
    void Start()
    {
        int day = PrefsManager.Instance.GetDay();
        numDia.GetComponent<TMPro.TextMeshProUGUI>().text = ""+day;

        List<(string, float)> events = PrefsManager.Instance.GetEvents(day);
        int numEvents = PlayerPrefs.GetInt(day+"_events");
        GameObject item = Instantiate (itemPrefab) as GameObject;
        item.transform.SetParent( content);
        item.GetComponent<ItemInitialize>().SetName("Ahorros");
        item.GetComponent<ItemInitialize>().SetValue(PrefsManager.Instance.GetMoney());
        item.transform.localScale = new Vector3(1,1,1);
        float total = 0;
        foreach( (string,float)ev in events)
        {
            string name = ev.Item1;
            float value = ev.Item2;
            total += value;

            item = Instantiate (itemPrefab) as GameObject;
            item.transform.SetParent( content);
            item.GetComponent<ItemInitialize>().SetName(name);
            item.GetComponent<ItemInitialize>().SetValue(value);
            item.transform.localScale = new Vector3(1,1,1);
        }

        TMPro.TextMeshProUGUI  TMvalue = valueObject.GetComponent<TMPro.TextMeshProUGUI>();

        TMvalue.text = "$ "  + (total >= 0 ? " " : "") + total.ToString();
        PrefsManager.Instance.AddMoney(total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
