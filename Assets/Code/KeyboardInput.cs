using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyboardInput : MonoX
{
	[SerializeField] private UILabel inputLbl;

	public Action<string> onCommandEntered;

	void Update() {
		if (!string.IsNullOrEmpty(Input.inputString)) {
			if (Input.inputString == "\b") {
				inputLbl.text = inputLbl.text.Substring(0, inputLbl.text.Length - 1);
			} if (Input.inputString == "\n" || Input.inputString == "\r") {
				if (onCommandEntered != null) onCommandEntered(inputLbl.text);
				inputLbl.text = string.Empty;
			} else {
				inputLbl.text += Input.inputString;
			}
		}
	}

	// void OnGUI() {
	// 	if (Event.current.isKey && Event.current.type == EventType.KeyUp) {
	// 		Debug.Log(Input.inputString);
	// 		inputLbl.text += Event.current.keyCode.ToString()
	// 	}
	// }

}
