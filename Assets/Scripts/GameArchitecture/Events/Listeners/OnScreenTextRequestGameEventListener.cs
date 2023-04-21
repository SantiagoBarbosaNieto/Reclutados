using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "OnScreenTextRequest")]
	public sealed class OnScreenTextRequestGameEventListener : BaseGameEventListener<OnScreenTextRequest, OnScreenTextRequestGameEvent, OnScreenTextRequestUnityEvent>
	{
	}
}