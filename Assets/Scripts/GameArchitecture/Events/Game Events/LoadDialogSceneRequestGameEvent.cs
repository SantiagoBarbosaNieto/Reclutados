using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "LoadDialogSceneRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Load Dialog Scene",
	    order = 120)]
	public sealed class LoadDialogSceneRequestGameEvent : GameEventBase<LoadDialogSceneRequest>
	{
	}
}