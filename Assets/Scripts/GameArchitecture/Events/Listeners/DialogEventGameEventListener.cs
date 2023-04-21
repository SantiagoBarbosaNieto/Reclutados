using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "DialogEvent")]
	public sealed class DialogEventGameEventListener : BaseGameEventListener<DialogEvent, DialogEventGameEvent, DialogEventUnityEvent>
	{
	}
}