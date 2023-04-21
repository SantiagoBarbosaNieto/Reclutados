using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "LoadDayRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Load Day",
	    order = 120)]
	public sealed class LoadDayRequestGameEvent : GameEventBase<LoadDayRequest>
	{
	}
}