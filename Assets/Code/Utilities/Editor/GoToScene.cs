using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public static class PoptokEnhancements
{

	[MenuItem("Enhancements/Go to Scene/Menu &1")]
	public static void GoToMenu() {
		OpenScene("Assets/Scenes/Menu.unity");
	}

	[MenuItem("Enhancements/Go to Scene/Game &2")]
	public static void GoToGame() {
		OpenScene("Assets/Scenes/Game.unity");
	}

	[MenuItem("Enhancements/Go to Scene/Pocket Dictionary &3")]
	public static void GoToPocketDict() {
		OpenScene("Assets/Scenes/PocketDict.unity");
	}

	static void OpenScene(string path) {
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo()) {
			EditorApplication.OpenScene(path);
		}
	}

}
