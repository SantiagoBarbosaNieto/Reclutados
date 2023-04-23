using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "AddMoneyGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Add Money Event",
	    order = 120)]
	public sealed class AddMoneyGameEvent : GameEventBase<AddMoney>
	{
	}
}