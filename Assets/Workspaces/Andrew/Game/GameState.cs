using Andtech.Automata;

internal enum Letter {
	Next,
	StartA,
	StartB,
	StartC,
	Win
}

public enum Level {
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
	public static int BossDefeatCount;

	public static Level CurrentLevel {
		get {
			machine.TryGetPresentState(out Level level);

			return level;
		}
	}

	private static readonly IStateMachine<Level, Letter> machine;

	static GameState() {
		DeltaFunction<Level, Letter> deltaFunction = new DynamicDeltaFunction<Level, Letter>(false) {
			(Level.Hub, Letter.StartA, Level.WalkingA),
			(Level.WalkingA, Letter.Next, Level.BossA),
			(Level.BossA, Letter.Next, Level.Hub),

			(Level.Hub, Letter.StartB, Level.WalkingB),
			(Level.WalkingB, Letter.Next, Level.BossB),
			(Level.BossB, Letter.Next, Level.Hub),

			(Level.Hub, Letter.StartC, Level.WalkingC),
			(Level.WalkingC, Letter.Next, Level.BossC),
			(Level.BossC, Letter.Next, Level.Hub),

			(Level.Hub, Letter.Win, Level.Ending)
		};

		StateMachine<Level, Letter> machine = new StateMachine<Level, Letter>(deltaFunction, Level.Hub) {
			retainCursorOnDeadTransitions = true
		};

		GameState.machine = machine;
	}

	public static void NextLevel() {
		machine.Step(Letter.Next);
	}

	public static void StartA() {
		machine.Step(Letter.StartA);
	}

	public static void StartB() {
		machine.Step(Letter.StartB);
	}

	public static void StartC() {
		machine.Step(Letter.StartC);
	}

	public static void Win() {
		machine.Step(Letter.Win);
	}
}
