using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "OnScreenTextRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "On Screen Text Request",
	    order = 120)]
	public sealed class OnScreenTextRequestGameEvent : GameEventBase<OnScreenTextRequest>
	{
	}
}