using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class LoadSceneRequestEvent : UnityEvent<LoadSceneRequest> { }

	[CreateAssetMenu(
	    fileName = "LoadSceneRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Load Scene",
	    order = 120)]
	public class LoadSceneRequestVariable : BaseVariable<LoadSceneRequest, LoadSceneRequestEvent>
	{
	}
}