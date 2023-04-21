using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class OnScreenTextRequestReference : BaseReference<OnScreenTextRequest, OnScreenTextRequestVariable>
	{
	    public OnScreenTextRequestReference() : base() { }
	    public OnScreenTextRequestReference(OnScreenTextRequest value) : base(value) { }
	}
}