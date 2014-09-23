using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
[Category ("Vitality Tests")]
public class VitalityTests
{

	[Test][Category("BLah")]
	public void IsDeadAfterMaxDamage() {
		Debug.Log("WAT");
		Assert.Pass();
	}

	[Test][Category("BLah")]
	public void IsAliveWithoutMaxDamage() {
		Assert.Pass();
	}

}
