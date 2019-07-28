using Andtech.Automata;

public enum Transition {
	Next,
	StartA,
	StartB,
	StartC,
	Win
}

public enum Level {
	None,

	Hub,

	WalkingA,
	BossA,

	WalkingB,
	BossB,

	WalkingC,
	BossC,

	Ending
}

public class GameState {
	public static bool HasHeart;
	public static bool HasBrain;
	public static bool HasCourage;

	public static int BossDefeatCount;

	public static Level CurrentLevel {
		get {
			machine.TryGetPresentState(out Level level);

			return level;
		}
	}

	public static EventStateMachine<Level, Transition> Machine => machine;

	private static readonly EventStateMachine<Level, Transition> machine;

	static GameState() {
		DeltaFunction<Level, Transition> deltaFunction = new DynamicDeltaFunction<Level, Transition>(false) {
			(Level.Hub, Transition.StartA, Level.BossA),
			(Level.WalkingA, Transition.Next, Level.BossA),
			(Level.BossA, Transition.Next, Level.Hub),

			(Level.Hub, Transition.StartB, Level.BossB),
			(Level.WalkingB, Transition.Next, Level.BossB),
			(Level.BossB, Transition.Next, Level.Hub),

			(Level.Hub, Transition.StartC, Level.BossC),
			(Level.WalkingC, Transition.Next, Level.BossC),
			(Level.BossC, Transition.Next, Level.Hub),

			(Level.Hub, Transition.Win, Level.Ending)
		};

		EventStateMachine<Level, Transition> machine = new EventStateMachine<Level, Transition>(deltaFunction, Level.Hub) {
			retainCursorOnDeadTransitions = true
		};

		GameState.machine = machine;
	}

	public static void NextLevel() {
		IStateMachine<Level, Transition> stateMachine = (machine as IStateMachine<Level, Transition>);

		stateMachine.Step(Transition.Next);
	}

	public static void StartA() {
		IStateMachine<Level, Transition> stateMachine = (machine as IStateMachine<Level, Transition>);

		stateMachine.Step(Transition.StartA);
	}

	public static void StartB() {
		IStateMachine<Level, Transition> stateMachine = (machine as IStateMachine<Level, Transition>);

		stateMachine.Step(Transition.StartB);
	}

	public static void StartC() {
		IStateMachine<Level, Transition> stateMachine = (machine as IStateMachine<Level, Transition>);

		stateMachine.Step(Transition.StartC);
	}

	public static void Win() {
		IStateMachine<Level, Transition> stateMachine = (machine as IStateMachine<Level, Transition>);

		stateMachine.Step(Transition.Win);
	}

	public static void Play() {

	}
}
