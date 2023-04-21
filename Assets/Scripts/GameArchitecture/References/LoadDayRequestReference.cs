using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LoadDayRequestReference : BaseReference<LoadDayRequest, LoadDayRequestVariable>
	{
	    public LoadDayRequestReference() : base() { }
	    public LoadDayRequestReference(LoadDayRequest value) : base(value) { }
	}
}