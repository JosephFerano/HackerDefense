using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandEvaluator : MonoX
{
	[SerializeField] private CategorySymbols[] categories;
	[SerializeField] private ParameterSymbols[] parameters;
	[SerializeField] private ExecutionSymbols[] executions;

	public Action<Command> onCommandSent;

	public void Evaluate(string userInput) {
		string[] sections = userInput.Split(' ');
		Category? category = null;
		Parameter? parameter = null;
		Execution? execution = null;
		foreach (var cat in categories) {
			if (cat.symbol == sections[0]) category = cat.category;
		}
		foreach (var param in parameters) {
			if (param.symbol == sections[0]) parameter = param.parameter;
		}
		foreach (var exec in executions) {
			if (exec.symbol == sections[0]) execution = exec.execution;
		}
		if (category != null && parameter != null && execution != null) {
			var command = new Command(category.Value, parameter.Value, execution.Value);
			if (onCommandSent != null) onCommandFound(command);
		}
	}

	[Serializable]
	public class CategorySymbols {
		public string symbol;
		public Category category;
	}

	[Serializable]
	public class ParameterSymbols {
		public string symbol;
		public Parameter parameter;
	}

	[Serializable]
	public class ExecutionSymbols {
		public string symbol;
		public Execution execution;
	}

}
