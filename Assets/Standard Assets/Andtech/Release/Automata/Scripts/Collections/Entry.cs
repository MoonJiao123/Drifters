
namespace Andtech.Automata.Collections {

	/// <summary>
	/// Container for data in a <see cref="StateDictionary{S, V}"/> or <see cref="TransitionDictionary{S, A, V}"/>.
	/// </summary>
	/// <typeparam name="V"></typeparam>
	public struct Entry<V> {
		public readonly V value;
		public readonly TransitionDirection direction;
		public readonly TransitionCondition condition;

		public Entry(V value, TransitionDirection direction, TransitionCondition condition) {
			this.value = value;
			this.direction = direction;
			this.condition = condition;
		}
	}
}
