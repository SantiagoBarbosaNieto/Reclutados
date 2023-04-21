using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "LoadSceneRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Load Scene",
	    order = 120)]
	public sealed class LoadSceneRequestGameEvent : GameEventBase<LoadSceneRequest>
	{
	}
}