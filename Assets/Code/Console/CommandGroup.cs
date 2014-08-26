using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class CommandGroup
{
	public Command command;
	public Argument argument;
	public Flag[] flags;
	public int amount;

	public CommandGroup(Command command, Argument argument, Flag[] flags, int amount) {
		this.command = command;
		this.argument = argument;
		this.flags = flags;
		this.amount = amount;
	}

}
