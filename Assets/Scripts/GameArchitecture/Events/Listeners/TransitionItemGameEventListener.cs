using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "TransitionItem")]
	public sealed class TransitionItemGameEventListener : BaseGameEventListener<TransitionItem, TransitionItemGameEvent, TransitionItemUnityEvent>
	{
	}
}