using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "TransitionItemGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Transition Item",
	    order = 120)]
	public sealed class TransitionItemGameEvent : GameEventBase<TransitionItem>
	{
	}
}