using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Defender : MonoX
{

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log(col);
		if (col.tag == "Virus") {
			var unit = col.GetComponent<Unit>();
			Block(unit);
		}
	}

	void Block(Unit unit) {
		unit.Remove();
	}

}
