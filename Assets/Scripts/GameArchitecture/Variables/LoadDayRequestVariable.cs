using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class LoadDayRequestEvent : UnityEvent<LoadDayRequest> { }

	[CreateAssetMenu(
	    fileName = "LoadDayRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Load Day",
	    order = 120)]
	public class LoadDayRequestVariable : BaseVariable<LoadDayRequest, LoadDayRequestEvent>
	{
	}
}