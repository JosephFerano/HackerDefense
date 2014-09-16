using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Defender : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Virus") {
			var unit = col.gameObject.GetComponent<Unit>();
			Block(unit);
		}
    }

	void Block(Unit unit) {
		unit.Remove();
	}

}
