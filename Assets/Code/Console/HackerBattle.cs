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
		keyboardInput.CommandEntered += OnCommandEntered;
		evaluator.CommandInvoked += OnCommandInvoked;
	}

	void OnCommandEntered(string input) {
		evaluator.Evaluate(input);
	}

	void OnCommandInvoked(CommandGroup commandGroup) {
		processor.Process(commandGroup);
	}

}
