using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "AddMoney")]
	public sealed class AddMoneyGameEventListener : BaseGameEventListener<AddMoney, AddMoneyGameEvent, AddMoneyUnityEvent>
	{
	}
}