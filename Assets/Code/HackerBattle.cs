using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HackerBattle : MonoX
{
	[SerializeField] private KeyboardInput keyboardInput;
	[SerializeField] private CommandEvaluator evaluator;

	void Awake() {
		keyboardInput.onCommandEntered += c => evaluator.Evaluate(c);
	}

}
