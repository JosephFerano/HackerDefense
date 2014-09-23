using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Hacker : MonoX
{
	[SerializeField] private int maxHealthAmount;
	[SerializeField] private int maxHackPower;
	[SerializeField] private CommandProcessor processor;

	private Vitality health;
	private Vitality hackPower;

	void Awake() {
		health = new Vitality(maxHealthAmount);
		hackPower = new Vitality(maxHackPower);
	}

}
