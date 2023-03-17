using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "LoadDayRequest")]
	public sealed class LoadDayRequestGameEventListener : BaseGameEventListener<LoadDayRequest, LoadDayRequestGameEvent, LoadDayRequestUnityEvent>
	{
	}
}