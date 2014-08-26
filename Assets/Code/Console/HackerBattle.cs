using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HackerBattle : MonoX
{
	[SerializeField] private KeyboardInput keyboardInput;
	[SerializeField] private CommandEvaluator evaluator;
	[SerializeField] private CommandProcessor processor;

	void Awake() {
		keyboardInput.onCommandEntered += ui => evaluator.Evaluate(ui);
		evaluator.onCommandFound += c => processor.Process(c);
	}

}
