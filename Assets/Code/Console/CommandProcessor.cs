using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	private CommandGroup commandGroup;
	
	public void Process(CommandGroup commandGroup) {
		Debug.Log("WAT");
		this.commandGroup = commandGroup;
	}

}
