using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class OnScreenTextRequestEvent : UnityEvent<OnScreenTextRequest> { }

	[CreateAssetMenu(
	    fileName = "OnScreenTextRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "On Screen Text Request",
	    order = 120)]
	public class OnScreenTextRequestVariable : BaseVariable<OnScreenTextRequest, OnScreenTextRequestEvent>
	{
	}
}