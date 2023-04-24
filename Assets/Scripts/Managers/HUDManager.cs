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

    public GameObject SimpleNotification;
    public TextMeshProUGUI notificationTitle;
    public TextMeshProUGUI notificationContent;


    public void UpdateUI()
    {
        _money = GameStateManager.Instance.GetTotalMoney();
        _day = GameStateManager.Instance._dia;

        dayText.GetComponent<TextMeshProUGUI>().text = "Día " + _day;
        moneyText.GetComponent<TextMeshProUGUI>().text = _money.ToString("F2") + "$";
    }

    public void EnableUI(bool enable)
    {
        dayText.gameObject.SetActive(enable);
        moneyText.gameObject.SetActive(enable);
    }

    public void HideNotification()
    {
        SimpleNotification.gameObject.SetActive(false);
    }

    public void UpdateAndShowNotification(NotificationContent content)
    {
        notificationTitle.text = content.title;
        notificationContent.text = content.content;
        SimpleNotification.gameObject.SetActive(true);
    }
}
