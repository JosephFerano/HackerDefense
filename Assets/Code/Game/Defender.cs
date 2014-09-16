using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Defender : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("TRIGGER ENTER");
    }

	void OnColliderEnter2D(Collision2D other) {
		Debug.Log("Collider ENTER");
		// if (col.tag == "Virus") {
		// 	var unit = col.GetComponent<Unit>();
		// 	Block(unit);
		// }
    }

	void Block(Unit unit) {
		unit.Remove();
	}

}
