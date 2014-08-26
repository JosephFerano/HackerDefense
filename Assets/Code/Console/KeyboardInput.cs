using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KeyboardInput : MonoX
{
	[SerializeField] private UILabel inputLbl;

	public Action<string> CommandEntered;
	private string currentInput;

	void Update() {
		if (!string.IsNullOrEmpty(Input.inputString)) {
			if (Input.inputString == "\b" && currentInput.Length > 0) {
				currentInput = currentInput.Substring(0, currentInput.Length - 1);
			} else if (Input.inputString == "\n" || Input.inputString == "\r") {
				if (CommandEntered != null) CommandEntered(currentInput);
				currentInput = string.Empty;
			} else {
				currentInput += Input.inputString;
			}
			inputLbl.text = currentInput;
		}
	}

}
