using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ScreenLogger : MonoBehaviour
{
	private UILabel label;

	void Awake() {
		label = GetComponent<UILabel>();
	}

	void OnEnable() {
		Application.RegisterLogCallback(PrintToLabel);
	}

	void OnDisable() {
		Application.RegisterLogCallback(null);
	}

	void PrintToLabel(string logString, string stackTrace, LogType logType) {
		if (logString.Contains("Log:")) {
			label.text = logString.Replace("Log:", "");
		}
	}

}
