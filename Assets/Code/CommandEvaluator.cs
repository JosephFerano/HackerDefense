using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandEvaluator : MonoX
{
	[SerializeField] private CategorySymbols[] categories;
	[SerializeField] private ParameterSymbols[] parameters;
	[SerializeField] private ExecutionSymbols[] executions;

	public void Evaluate(string command) {
		string[] sections = command.Split(' ');
		foreach (var s in sections) {
			Debug.Log(s);
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
