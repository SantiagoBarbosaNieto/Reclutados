using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "NotificationContent")]
	public sealed class NotificationContentGameEventListener : BaseGameEventListener<NotificationContent, NotificationContentGameEvent, NotificationContentUnityEvent>
	{
	}
}