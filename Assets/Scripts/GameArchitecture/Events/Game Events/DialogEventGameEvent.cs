using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "DialogEventGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Dialog Event",
	    order = 120)]
	public sealed class DialogEventGameEvent : GameEventBase<DialogEvent>
	{
	}
}