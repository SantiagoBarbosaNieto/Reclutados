using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LoadSceneRequestReference : BaseReference<LoadSceneRequest, LoadSceneRequestVariable>
	{
	    public LoadSceneRequestReference() : base() { }
	    public LoadSceneRequestReference(LoadSceneRequest value) : base(value) { }
	}
}