using Andtech.Automata.Collections;
using System;
using System.Collections.Generic;

namespace Andtech.Automata {

	/// <summary>
	/// <see cref="StateMachine{S, A}"/> with support for intercepted events.
	/// </summary>
	/// <typeparam name="S">The type of the states.</typeparam>
	/// <typeparam name="A">The type of the letters.</typeparam>
	public class EventStateMachine<S, A> : StateMachine<S, A> {
		public bool invokeEnterActionsOnJump;
		public bool invokeExitActionsOnJump;

		private readonly StateDictionary<S, ActionInfo> stateActions;
		private readonly TransitionDictionary<S, A, ActionInfo> transitionActions;

		public EventStateMachine(DeltaFunction<S, A> deltaFunction, params S[] startStates) : this(deltaFunction, (ICollection<S>)startStates) { }

		public EventStateMachine(DeltaFunction<S, A> deltaFunction, ICollection<S> startStates) : base(deltaFunction, startStates) {
			stateActions = new StateDictionary<S, ActionInfo>(deltaFunction.States);
			transitionActions = new TransitionDictionary<S, A, ActionInfo>(deltaFunction.States, deltaFunction.Alphabet);
			invokeEnterActionsOnJump = true;
			invokeExitActionsOnJump = true;
		}

		/// <summary>
		/// Registers an action to a state.
		/// </summary>
		/// <param name="state">The target state.</param>
		/// <param name="action">The action to be invoked.</param>
		/// <param name="direction">The directional constraint.</param>
		/// <param name="condition">The conditional constraint.</param>
		public void AddStateAction(S state, Action action, TransitionDirection direction = TransitionDirection.Enter, TransitionCondition condition = TransitionCondition.Always) {
			ActionInfo actionInfo = new ActionInfo(action);
			stateActions.Add(state, actionInfo, direction, condition);
		}

		/// <summary>
		/// Registers an action to a transition.
		/// </summary>
		/// <param name="state">The target state.</param>
		/// <param name="letter">The target transitioning letter.</param>
		/// <param name="action">The action to be invoked.</param>
		/// <param name="direction">The directional constraint.</param>
		/// <param name="condition">The conditional constraint.</param>
		public void AddTransitionAction(S state, A letter, Action action, TransitionDirection direction = TransitionDirection.Exit, TransitionCondition condition = TransitionCondition.Always) {
			ActionInfo actionInfo = new ActionInfo(action);
			transitionActions.Add(state, letter, actionInfo, direction, condition);
		}

		#region OVERRIDE
		/// <summary>
		/// Forces the machine to have the specified present states.
		/// </summary>
		/// <param name="states">The new present states.</param>
		public override void Set(IEnumerable<S> states) {
			// Perform exit action(s)
			if (invokeExitActionsOnJump) {
				foreach (S state in cursors) {
					foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Exit)) {
						actionInfo.action.Invoke();
					}
				}
			}

			base.Set(states);

			// Perform enter action(s)
			if (invokeEnterActionsOnJump) {
				foreach (S state in cursors) {
					foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Enter)) {
						actionInfo.action.Invoke();
					}
				}
			}
		}

		/// <summary>
		/// Advance the machine to the next state(s).
		/// </summary>
		/// <seealso cref="StateMachine{S, A}.Step(A)"/>
		/// <param name="letter">The letter used for transitioning.</param>
		protected override void Step(A letter) {
			// Perform exit action(s)
			foreach (S state in cursors) {
				try {
					foreach (S nextState in deltaFunction.Evaluate(state, letter)) {
						TransitionCondition condition = nextState.Equals(state) ? TransitionCondition.Self : TransitionCondition.NotSelf;

						// Perform exit action(s)
						foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Exit, condition)) {
							actionInfo.action.Invoke();
						}
						foreach (ActionInfo actionInfo in transitionActions.GetEnumerator(state, letter, TransitionDirection.Exit, condition)) {
							actionInfo.action.Invoke();
						}

						// Perform enter action(s)
						foreach (ActionInfo actionInfo in stateActions.GetEnumerator(nextState, TransitionDirection.Enter, condition)) {
							actionInfo.action.Invoke();
						}
						foreach (ActionInfo actionInfo in transitionActions.GetEnumerator(nextState, letter, TransitionDirection.Enter, condition)) {
							actionInfo.action.Invoke();
						}
					}
				}
				catch (UndefinedTransitionException) {
					if (!retainCursorOnDeadTransitions) {
						// Perform exit action(s) on dead transitions
						foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Exit, TransitionCondition.NotSelf)) {
							actionInfo.action.Invoke();
						}
						
						foreach (ActionInfo actionInfo in transitionActions.GetEnumerator(state, letter, TransitionDirection.Exit, TransitionCondition.NotSelf)) {
							actionInfo.action.Invoke();
						}
					}
				}
			}

			// Update the machine
			base.Step(letter);
		}

		/// <summary>
		/// Restores the machine to the initial state.
		/// </summary>
		/// <seealso cref="StateMachine{S, A}.Reset"/>
		protected override void Reset() {
			// Perform exit action(s)
			if (invokeExitActionsOnJump) {
				foreach (S state in cursors) {
					foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Exit, TransitionCondition.Always)) {
						actionInfo.action.Invoke();
					}
				}
			}

			// Update the machine
			base.Reset();

			// Perform enter actions(s)
			if (invokeEnterActionsOnJump) {
				foreach (S state in cursors) {
					foreach (ActionInfo actionInfo in stateActions.GetEnumerator(state, TransitionDirection.Enter, TransitionCondition.Always)) {
						actionInfo.action.Invoke();
					}
				}
			}
		}
		#endregion OVERRIDE
	}
}
