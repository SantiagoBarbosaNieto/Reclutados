using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "NotificationContentGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "NotificationContent",
	    order = 120)]
	public sealed class NotificationContentGameEvent : GameEventBase<NotificationContent>
	{
	}
}