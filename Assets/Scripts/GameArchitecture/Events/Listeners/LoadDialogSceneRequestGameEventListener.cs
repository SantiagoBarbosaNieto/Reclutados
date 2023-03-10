using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "LoadDialogSceneRequest")]
	public sealed class LoadDialogSceneRequestGameEventListener : BaseGameEventListener<LoadDialogSceneRequest, LoadDialogSceneRequestGameEvent, LoadDialogSceneRequestUnityEvent>
	{
	}
}