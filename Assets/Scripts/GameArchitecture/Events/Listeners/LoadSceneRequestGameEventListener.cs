using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "LoadSceneRequest")]
	public sealed class LoadSceneRequestGameEventListener : BaseGameEventListener<LoadSceneRequest, LoadSceneRequestGameEvent, LoadSceneRequestUnityEvent>
	{
	}
}