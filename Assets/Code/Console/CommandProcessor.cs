using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	[SerializeField] private Spawner spawner;

	private CommandGroup commandGroup;
	
	public void Process(CommandGroup commandGroup) {
		this.commandGroup = commandGroup;
		if (commandGroup.command == Command.Attack && commandGroup.argument == Argument.Virus) {
			Lane lane = Lane.Middle;
			foreach (var flag in commandGroup.flags) {
				if (flag == Flag.Top) lane = Lane.Top;
				else if (flag == Flag.Bottom) lane = Lane.Bottom;
			}
			Unit virus = spawner.Spawn(UnitType.Virus, lane, Side.Left);
			virus.GetComponent<Mover>().Move(Vector2.right);
		}
	}

}
