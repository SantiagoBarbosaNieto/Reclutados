using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class TransitionItemEvent : UnityEvent<TransitionItem> { }

	[CreateAssetMenu(
	    fileName = "TransitionItemVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Transition Item",
	    order = 120)]
	public class TransitionItemVariable : BaseVariable<TransitionItem, TransitionItemEvent>
	{
	}
}