using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int interest;
    public int patience;
    public int maxInterest;

    public void UpdateIndicators(int interestChange, int patienceChange)
    {
        interest = Mathf.Clamp(interest + interestChange, 0, maxInterest);
        patience = Mathf.Max(patience + patienceChange, 0);
    }
}
