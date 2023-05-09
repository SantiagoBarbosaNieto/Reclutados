using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ItemSpawner : MonoBehaviour
{
    public Object itemPrefab;
    public Transform content;
    public Transform valueObject;
    public Transform numDia; 

    public GameObject buttonObject;

    public GameEvent gameOverEvent;
    public GameEvent nextDayEvent;

    // Start is called before the first frame update
    void Start()
    {
        int day = GameStateManager.Instance._dia;
        numDia.GetComponent<TMPro.TextMeshProUGUI>().text = ""+day;

        List<GameStateManager.Evento> events = GameStateManager.Instance.GetCurrentDayEvents();
        
        //Item de ahorros
        GameObject item = Instantiate (itemPrefab) as GameObject;
        item.transform.SetParent( content);
        item.GetComponent<ItemInitialize>().SetName("Ahorros");
        float ahorro = GameStateManager.Instance._moneyDayStart;
        item.GetComponent<ItemInitialize>().SetValue(ahorro);

        item.transform.localScale = new Vector3(1,1,1);


        float salesTotal = 0;
        foreach( GameStateManager.Evento ev in events)
        {
            string name = ev._nombre;
            float value = ev._valor;
            if(ev.isVentas)
            {
                salesTotal += value;
            }
            else
            {
                item = Instantiate (itemPrefab) as GameObject;
                item.transform.SetParent( content);
                item.GetComponent<ItemInitialize>().SetName(name);
                item.GetComponent<ItemInitialize>().SetValue(value);
                item.transform.localScale = new Vector3(1,1,1);
            }

        }

        item = Instantiate (itemPrefab) as GameObject;
        item.transform.SetParent( content);
        item.GetComponent<ItemInitialize>().SetName("Total Ventas");
        item.GetComponent<ItemInitialize>().SetValue(salesTotal);
        item.transform.localScale = new Vector3(1,1,1);

        TMPro.TextMeshProUGUI  TMvalue = valueObject.GetComponent<TMPro.TextMeshProUGUI>();
        float screenTotal = GameStateManager.Instance.GetTotalMoney();
        TMvalue.text = "$ "  + (screenTotal >= 0 ? " " : "") + screenTotal.ToString("F2");

        buttonObject.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        if(screenTotal < 0)
        {
            buttonObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => gameOverEvent.Raise());
        }
        else
        {
            buttonObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => nextDayEvent.Raise());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
