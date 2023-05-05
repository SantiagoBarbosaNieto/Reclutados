using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfoExpense 
{
    public string description;
    public float money;

    public InfoExpense( float money, string description = "") {
        this.description = description;
        this.money = money;
    }
}
