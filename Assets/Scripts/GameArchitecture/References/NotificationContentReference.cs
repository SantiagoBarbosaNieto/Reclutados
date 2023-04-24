using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class NotificationContentReference : BaseReference<NotificationContent, NotificationContentVariable>
	{
	    public NotificationContentReference() : base() { }
	    public NotificationContentReference(NotificationContent value) : base(value) { }
	}
}