using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "NotificationContentGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "UpdateAndShowNotification Event",
	    order = 120)]
	public sealed class NotificationContentGameEvent : GameEventBase<NotificationContent>
	{
	}
}