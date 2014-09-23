using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitCollisionChecker : MonoX
{

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Mainframe") {
			if (col.gameObject.tag != tag) {
				var unit = col.gameObject.GetComponent<Unit>();
				unit.Remove();
			}
		}
	}

}
