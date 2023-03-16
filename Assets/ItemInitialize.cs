using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInitialize : MonoBehaviour
{
    public new string name = "Test";
    public float value = 0;
    public Color positiveColor = Color.green;
    public Color negativeColor = Color.red;
    // Start is called before the first frame update
    
    private Transform  NameGameObject;
    private Transform ValueGameObject;    
    void Start()
    {
        NameGameObject = transform.Find("Name");
        NameGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        

    }

    // Update is called once per frame
    void Update()
    {
        ValueGameObject = transform.Find("Value");
        TMPro.TextMeshProUGUI TMvalue = ValueGameObject.GetComponent<TMPro.TextMeshProUGUI>();
        if (value >= 0)
        {
            TMvalue.faceColor  = positiveColor;
        }
        else
        {
            TMvalue.faceColor  = negativeColor;
        }
        TMvalue.text = "$ "  + (value >= 0 ? " " : "") + value.ToString();
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public void SetValue(int newVal)
    {
        value = newVal;
    }
}
