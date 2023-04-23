using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AddMoneyReference : BaseReference<AddMoney, AddMoneyVariable>
	{
	    public AddMoneyReference() : base() { }
	    public AddMoneyReference(AddMoney value) : base(value) { }
	}
}