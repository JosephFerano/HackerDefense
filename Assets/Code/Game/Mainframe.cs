using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Mainframe : MonoX
{
	[SerializeField] private float tickInterval;
	[SerializeField] private Hacker mainFrameHacker;
	[SerializeField] private CommandProcessor processor;

	private float timeElapsed;

	void Awake() {
	}

	void Update() {
		if (timeElapsed <= tickInterval) {
			timeElapsed += Time.deltaTime;
		} else {
			timeElapsed = 0;
			Behave();
		}
	}

	void Behave() {
		int randAction = UnityEngine.Random.Range(0, 2);
		int randLane = UnityEngine.Random.Range(0, 3);
		Command command = randAction == 0 ? Command.Attack : Command.Defense;
		Argument argument = randAction == 0 ? Argument.Virus : Argument.Firewall;
		Flag[] flags = new Flag[1];
		flags[0] = (Flag)randLane;
		var commandGroup = new CommandGroup(command, argument, flags, 0);
		processor.Process(commandGroup, Side.Right);
	}

}
