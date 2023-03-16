using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class LoadDialogSceneRequestEvent : UnityEvent<LoadDialogSceneRequest> { }

	[CreateAssetMenu(
	    fileName = "LoadDialogSceneRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Load Dialog Scene",
	    order = 120)]
	public class LoadDialogSceneRequestVariable : BaseVariable<LoadDialogSceneRequest, LoadDialogSceneRequestEvent>
	{
	}
}