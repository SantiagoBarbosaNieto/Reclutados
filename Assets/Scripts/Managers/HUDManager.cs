using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private float _money;

    private int _day;

    public GameObject dayText;
    public GameObject moneyText;

    public void UpdateUI()
    {
        _money = PrefsManager.Instance.GetSalesMoney();
        _day = PrefsManager.Instance.GetDay();
        Debug.Log("UPDATE MONEY: " + _money);

        dayText.GetComponent<TextMeshProUGUI>().text = "Día " + _day;
        moneyText.GetComponent<TextMeshProUGUI>().text = _money + "$";
    }

    public void EnableUI(bool enable)
    {
        dayText.gameObject.SetActive(enable);
        moneyText.gameObject.SetActive(enable);
    }
}
