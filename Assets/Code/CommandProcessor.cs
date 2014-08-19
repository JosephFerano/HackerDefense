using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommandProcessor : MonoX
{
	
	public void Process() {
	}

}

public enum Category
{
	Attack,
	Defense,
	Upgrade
}

public enum Parameter
{
	Top,
	Middle,
	Bottom
}

public enum Execution
{
	Firewall,
	Trojan,
	VirusProtection,
	Virus
}
