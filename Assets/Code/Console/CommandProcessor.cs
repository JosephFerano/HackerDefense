using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	[SerializeField] private Spawner spawner;

	public Action<Unit, Lane> UnitSpawned;
	private Side side;
	private CommandGroup commandGroup;

	public void Process(CommandGroup commandGroup, Side side) {
		this.side = side;
		this.commandGroup = commandGroup;
		if (commandGroup.command == Command.Attack && commandGroup.argument == Argument.Virus) {
			SendVirus();
		} else if (commandGroup.command == Command.Defense && commandGroup.argument == Argument.Firewall) {
			CreateFirewall();
		}
	}

	void SendVirus() {
		Unit virus = spawner.Spawn(UnitType.Virus, GetLane(commandGroup), side);
		Vector2 direction = side == Side.Left ? Vector2.right : -Vector2.right;
		AssignTag(virus.gameObject);
		virus.GetComponent<Mover>().Move(direction);
	}

	void CreateFirewall() {
		Unit firewall = spawner.Spawn(UnitType.Firewall, GetLane(commandGroup), side);
		AssignTag(firewall.gameObject);
	}

	void AssignTag(GameObject go) {
		go.tag = side == Side.Left ? "Player" : "Mainframe";
	}

	Lane GetLane(CommandGroup commandGroup) {
		Lane lane = Lane.Middle;
		foreach (var flag in commandGroup.flags) {
			if (flag == Flag.Top) lane = Lane.Top;
			else if (flag == Flag.Bottom) lane = Lane.Bottom;
		}
		return lane;
	}

}
