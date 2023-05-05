using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TriggerChecker : MonoBehaviour {

    [Header("Extra config")]
    public string validTag;

    [Header("Events")]
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    public NotificationContentGameEvent notificationEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(validTag))
        {
            if(GameStateManager.Instance._backpack.isEmpty())
            {
                Debug.Log("Maleta vacía");
                notificationEvent.Raise(new NotificationContent("Maleta vacía", "No tienes nada para vender! Recoje al menos 1 item de la granja para poder venderlo en el pueblo."));
                return;
            }
            else if (onTriggerEnter != null)
                onTriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(validTag))
        {
            if (onTriggerStay != null)
                onTriggerStay.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(validTag))
        {
            if (onTriggerExit != null)
                onTriggerExit.Invoke();
        }
    }
}
