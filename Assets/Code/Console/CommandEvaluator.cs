using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandEvaluator : MonoX
{
	[SerializeField] private CommandSymbols[] commandSymbols;
	[SerializeField] private ArgumentSymbols[] argumentSymbols;
	[SerializeField] private FlagSymbols[] flagSymbols;

	public Action<CommandGroup, Side> CommandInvoked;

	public void Evaluate(string userInput) {
		List<string> sections = new List<string>();
		sections.AddRange(userInput.Split(' '));
		Command? command = null;
		Argument? argument = null;
		List<Flag> flags = new List<Flag>();
		int amountFlag = 0;
		foreach (var cmd in commandSymbols) {
			if (cmd.symbol == sections[0]) command = cmd.command;
		}
		foreach (var arg in argumentSymbols) {
			bool didGetArg = false;
			for (int i = 1; i < sections.Count; i++) {
				if (arg.symbol == sections[i]) {
					argument = arg.argument;
					didGetArg = true;
					break;
				}
			}
			if (didGetArg) break;
		}
		foreach (var fl in flagSymbols) {
			for (int i = 0; i < sections.Count; i++) {
				if (fl.symbol == sections[i]) {
					flags.Add(fl.flag);
				}
			}
		}
		foreach (var section in sections) {
			if (int.TryParse(section, out amountFlag)) break;
		}
		if (command != null && argument != null) {
			var commandGroup = new CommandGroup(command.Value, argument.Value, flags.ToArray(), amountFlag);
			if (CommandInvoked != null) CommandInvoked(commandGroup, Side.Left);
		}
	}

	[Serializable]
	public class CommandSymbols{
		public string symbol;
		public Command command;
	}

	[Serializable]
	public class ArgumentSymbols {
		public string symbol;
		public Argument argument;
	}

	[Serializable]
	public class FlagSymbols {
		public string symbol;
		public Flag flag;
	}

}
