using System;

namespace Andtech.Automata {

	internal struct ActionInfo {
		public readonly Action action;

		public ActionInfo(Action action) {
			this.action = action;
		}
	}
}