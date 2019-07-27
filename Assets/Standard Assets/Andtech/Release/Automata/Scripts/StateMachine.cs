using System;
using System.Collections.Generic;

namespace Andtech.Automata {

	/// <summary>
	/// Basic state machine.
	/// </summary>
	/// <typeparam name="S">The type of the states.</typeparam>
	/// <typeparam name="A">The type of the letters.</typeparam>
	public class StateMachine<S, A> : IStateMachine<S, A> {
		/// <summary>
		/// Whether a cursor should be removed when no transitions are available.
		/// </summary>
		public bool retainCursorOnDeadTransitions;

		protected readonly DeltaFunction<S, A> deltaFunction;		
		protected readonly IEnumerable<S> startStates;
		protected readonly LinkedList<S> cursors;

		public StateMachine(DeltaFunction<S, A> deltaFunction, params S[] startStates) : this(deltaFunction, (IEnumerable<S>)startStates) { }

		public StateMachine(DeltaFunction<S, A> deltaFunction, IEnumerable<S> startStates) {
			this.deltaFunction = deltaFunction;
			this.startStates = startStates;
			cursors = new LinkedList<S>(startStates);
			retainCursorOnDeadTransitions = false;
		}

		#region VIRTUAL
		/// <summary>
		/// Forces the machine to have the specified present states.
		/// </summary>
		/// <param name="states">The new present states.</param>
		public virtual void Set(params S[] states) {
			cursors.Clear();
			foreach (S state in states) {
				cursors.AddLast(state);
			}
		}

		/// <summary>
		/// Forces the machine to have the specified present states.
		/// </summary>
		/// <param name="states">The new present states.</param>
		public virtual void Set(IEnumerable<S> states) {
			cursors.Clear();
			foreach (S state in states) {
				cursors.AddLast(state);
			}
		}

		/// <summary>
		/// Advance the machine to the next state(s).
		/// </summary>
		/// <param name="letter">The letter used for transitioning.</param>
		protected virtual void Step(A letter) {
			ICollection<S> pending = new LinkedList<S>();

			foreach (S state in cursors) {
				try {
					foreach (S nextState in deltaFunction.Evaluate(state, letter)) {
						if (!pending.Contains(nextState))
							pending.Add(nextState);
					}
				}
				catch (UndefinedTransitionException) {
					if (retainCursorOnDeadTransitions) {
						if (!pending.Contains(state))
							pending.Add(state);
					}
				}
			}

			Set(pending);

			OnFinishStep(EventArgs.Empty);
		}

		/// <summary>
		/// Restores the machine to the initial state.
		/// </summary>
		protected virtual void Reset() {
			Set(startStates);
		}
		#endregion VIRTUAL

		#region INTERFACE
		IEnumerable<S> IStateMachine<S, A>.States => cursors;

		void IStateMachine<S, A>.Step(A letter) => Step(letter);

		void IStateMachine<S, A>.Reset() => Reset();
		#endregion INTERFACE

		#region EVENT
		public event EventHandler FinishedStep;

		protected virtual void OnFinishStep(EventArgs e) => FinishedStep?.Invoke(this, e);
		#endregion EVENT
	}
}
