using System;

namespace Andtech.Automata {

	/// <summary>
	/// Description of a transition constraint.
	/// </summary>
	[Flags]
	public enum TransitionCondition {
		Never		= 0,
		Self		= (1 << 0),
		NotSelf		= (1 << 1),

		Always		= -1
	}
}
