using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LoadDialogSceneRequestReference : BaseReference<LoadDialogSceneRequest, LoadDialogSceneRequestVariable>
	{
	    public LoadDialogSceneRequestReference() : base() { }
	    public LoadDialogSceneRequestReference(LoadDialogSceneRequest value) : base(value) { }
	}
}