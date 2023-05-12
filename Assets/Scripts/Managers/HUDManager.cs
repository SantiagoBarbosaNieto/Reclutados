using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ScriptableObjectArchitecture;

public class HUDManager : MonoBehaviour
{
    private float _money;

    private int _day;

    public GameObject dayText;
    public GameObject moneyText;

    public GameObject statsInfo;

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
        statsInfo.gameObject.SetActive(enable);
    }


//Notification
    public void AddButtonAction(NotificationContent.Action action)
    {   
        SimpleNotification.transform.Find("Notification/Button").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => action());
    }

    
    private void ResetButtonActions()
    {
        SimpleNotification.transform.Find("Notification/Button").GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        SimpleNotification.transform.Find("Notification/Button").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => HideNotification());
    }

    public void HideNotification()
    {
        ResetButtonActions();
        SimpleNotification.gameObject.SetActive(false);
    }

    public void UpdateAndShowNotification(NotificationContent content)
    {
        notificationTitle.text = content.title;
        notificationContent.text = content.content;
        if(content.action != null)
        {
            AddButtonAction(content.action);
        }
        SimpleNotification.gameObject.SetActive(true);
    }
}
