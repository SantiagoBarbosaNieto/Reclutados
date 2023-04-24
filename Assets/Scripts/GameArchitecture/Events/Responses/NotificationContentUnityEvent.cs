using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class NotificationContentUnityEvent : UnityEvent<NotificationContent>
	{
	}
}