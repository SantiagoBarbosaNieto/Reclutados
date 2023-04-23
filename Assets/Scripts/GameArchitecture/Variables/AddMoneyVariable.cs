using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class AddMoneyEvent : UnityEvent<AddMoney> { }

	[CreateAssetMenu(
	    fileName = "AddMoneyVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Add Money Event",
	    order = 120)]
	public class AddMoneyVariable : BaseVariable<AddMoney, AddMoneyEvent>
	{
	}
}