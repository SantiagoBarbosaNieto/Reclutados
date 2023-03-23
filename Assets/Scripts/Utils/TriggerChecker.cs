using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class TriggerChecker : MonoBehaviour
{
    public GameEvent gameEvent;

    [Header("Extra config")]
    public string validTag;

    [Header("Events")]
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(validTag))
        {
            if (onTriggerEnter != null)
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

    public void advanceScene()
    {
        gameEvent.Raise();
    }
}
