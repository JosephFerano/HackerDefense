using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	[SerializeField] private Spawner spawner;

	public void Process(CommandGroup commandGroup) {
		if (commandGroup.command == Command.Attack && commandGroup.argument == Argument.Virus) {
			SendVirus(commandGroup);
		} else if (commandGroup.command == Command.Defense && commandGroup.argument == Argument.Firewall) {
			CreateFirewall(commandGroup);
		}
	}

	void SendVirus(CommandGroup commandGroup) {
		Lane lane = Lane.Middle;
		foreach (var flag in commandGroup.flags) {
			if (flag == Flag.Top) lane = Lane.Top;
			else if (flag == Flag.Bottom) lane = Lane.Bottom;
		}
		Unit virus = spawner.Spawn(UnitType.Virus, lane, Side.Left);
		virus.GetComponent<Mover>().Move(Vector2.right);
	}

	void CreateFirewall(CommandGroup commandGroup) {
		Lane lane = Lane.Middle;
		foreach (var flag in commandGroup.flags) {
			if (flag == Flag.Top) lane = Lane.Top;
			else if (flag == Flag.Bottom) lane = Lane.Bottom;
		}
		Unit virus = spawner.Spawn(UnitType.Firewall, lane, Side.Right);
	}

}
