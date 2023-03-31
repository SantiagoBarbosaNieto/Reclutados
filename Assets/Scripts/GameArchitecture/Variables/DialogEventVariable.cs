using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class DialogEventEvent : UnityEvent<DialogEvent> { }

	[CreateAssetMenu(
	    fileName = "DialogEventVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Dialog Event",
	    order = 120)]
	public class DialogEventVariable : BaseVariable<DialogEvent, DialogEventEvent>
	{
	}
}