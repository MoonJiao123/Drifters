using Andtech.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Andtech.Automata.Collections {

	/// <summary>
	/// Associates (multiple) values with states.
	/// </summary>
	/// <typeparam name="S">The type of the keys (states).</typeparam>
	/// <typeparam name="V">The type of the values.</typeparam>
	public class StateDictionary<S, V> {
		private readonly MultiDictionary<S, Entry<V>> data;

		public StateDictionary(ICollection<S> states) {
			data = new MultiDictionary<S, Entry<V>>(states.Count);
		}

		public void Add(S state, V value, TransitionDirection direction, TransitionCondition condition = TransitionCondition.Always) {
			Entry<V> entry = new Entry<V>(value, direction, condition);
			data.Add(state, entry);
		}

		public IEnumerable<V> GetEnumerator(S state, TransitionDirection directionMask, TransitionCondition conditionMask = TransitionCondition.Always) {
			if (data.ContainsKey(state)) {
				foreach (Entry<V> entry in data[state].Where(
					x =>
					(x.direction & directionMask) != 0 &&
					(x.condition & conditionMask) != 0)) {
					yield return entry.value;
				}
			}
		}
	}
}
