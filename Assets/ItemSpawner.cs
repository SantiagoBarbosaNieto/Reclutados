using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Object itemPrefab;
    public Transform content;

    private GameObject prefab = null;
    void Awake() 
    {

        int day = PlayerPrefs.GetInt("day");
        int numEvents = PlayerPrefs.GetInt(day+"_events");

        for(int i = 0; i < numEvents; i++)
        {
            string name = PlayerPrefs.GetString(day+"_event_name_"+i);
            int value = PlayerPrefs.GetInt(day+"_event_value_"+i);
            
            GameObject item = Instantiate (itemPrefab) as GameObject;
            item.transform.SetParent( content);
            item.GetComponent<ItemInitialize>().SetName(name);
            item.GetComponent<ItemInitialize>().SetValue(value);
        }

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
