using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class NotificationContentEvent : UnityEvent<NotificationContent> { }

	[CreateAssetMenu(
	    fileName = "NotificationContentVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "NotificationContent",
	    order = 120)]
	public class NotificationContentVariable : BaseVariable<NotificationContent, NotificationContentEvent>
	{
	}
}