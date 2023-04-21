using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class DialogEventReference : BaseReference<DialogEvent, DialogEventVariable>
	{
	    public DialogEventReference() : base() { }
	    public DialogEventReference(DialogEvent value) : base(value) { }
	}
}