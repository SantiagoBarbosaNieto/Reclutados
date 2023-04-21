using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class TransitionItemReference : BaseReference<TransitionItem, TransitionItemVariable>
	{
	    public TransitionItemReference() : base() { }
	    public TransitionItemReference(TransitionItem value) : base(value) { }
	}
}